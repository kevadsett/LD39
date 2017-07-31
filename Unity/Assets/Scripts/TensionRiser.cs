using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensionRiser : MonoBehaviour
{
	public Transform Player;

	public float MaxDist = 10f;

	public AnimationCurve Curve;

#if UNITY_WEBGL
	private AudioSource _source;
#else
	public float HighCutoff = 2000f;

	public float LowCutoff = 20f;

	private AudioLowPassFilter _lowPass;
#endif

	private List<Transform> _enemies = new List<Transform>();

	void Start ()
	{
#if UNITY_WEBGL
		_source = GetComponent<AudioSource>();
#else
		_lowPass = GetComponent<AudioLowPassFilter> ();
#endif
		Transform enemies = GameObject.Find ("Enemies").transform;
		foreach (Transform enemy in enemies)
		{
			_enemies.Add (enemy);
		}
	}

	void Update ()
	{
		float minDist = float.MaxValue;
		
		for (int i = 0; i < _enemies.Count; i++)
		{
			minDist = Mathf.Min (minDist, (_enemies [i].position - Player.position).magnitude);
		}

		if (minDist > MaxDist)
		{
#if UNITY_WEBGL
			_source.volume = 0;
#else
			_lowPass.cutoffFrequency = LowCutoff;
#endif
			return;
		}

		float position = Curve.Evaluate(1 - (minDist / MaxDist));

#if UNITY_WEBGL
		_source.volume = position * 0.2f;
#else
		float frequencyRange = HighCutoff - LowCutoff;

		float frequency = LowCutoff + (frequencyRange * position);

		_lowPass.cutoffFrequency = frequency;
#endif
	}
}
