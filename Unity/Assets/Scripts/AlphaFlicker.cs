using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaFlicker : MonoBehaviour
{
	float TimeScale = 10f;

	private Renderer _renderer;

	private float _alpha = 1.0f;

	private bool _flickering;

	private float _flickerDuration;

	private float _flickerStartTime;

	void Start ()
	{
		_renderer = GetComponent<Renderer> ();
	}
	
	void Update ()
	{
		if (Random.value > 0.995f && !_flickering)
		{
			_flickering = true;
			_flickerDuration = Random.Range (0.2f, 0.5f);
			_flickerStartTime = Time.time;
		}

		if (_flickering)
		{
			_alpha = Mathf.PerlinNoise (Time.time * TimeScale, 0.0f);
			if (Time.time - _flickerStartTime >= _flickerDuration)
			{
				_flickering = false;
				_alpha = 1;
			}
		}

		_renderer.material.SetFloat ("_TransparencyModifier", _alpha);
	}
}
