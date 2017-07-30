using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensionRiser : MonoBehaviour
{
	public Transform Player;

	public float MaxDist = 10f;

	public float HighCutoff = 2000f;

	public float LowCutoff = 20f;

	public AnimationCurve Curve;

	private AudioLowPassFilter _lowPass;

	private List<Transform> _enemies = new List<Transform>();

	void Start ()
	{
		_lowPass = GetComponent<AudioLowPassFilter> ();
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
			_lowPass.cutoffFrequency = LowCutoff;
			return;
		}

		float position = Curve.Evaluate(1 - (minDist / MaxDist));

		float frequencyRange = HighCutoff - LowCutoff;

		float frequency = LowCutoff + (frequencyRange * position);

		_lowPass.cutoffFrequency = frequency;
	}
}
