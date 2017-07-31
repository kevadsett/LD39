using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientCalls : MonoBehaviour {
	public List<AudioClip> Sounds;

	public float MaximumWait = 10f;

	private AudioSource _audioSource;

	private float _lastPlayTime;

	void Start ()
	{
		_audioSource = GetComponent<AudioSource> ();
		_lastPlayTime = Time.time;
	}

	void Update ()
	{
		if (Random.value > 0.999 && !_audioSource.isPlaying)
		{
			PlaySound ();
		}
		else
		{
			if (Time.time - _lastPlayTime >= MaximumWait)
			{
				PlaySound ();
			}
		}
	}

	public void PlaySound(float volume = -1f)
	{
		_audioSource.clip = Sounds [Random.Range (0, Sounds.Count)];
		_audioSource.Play ();
		_audioSource.panStereo = Random.Range (-1f, 1f);
		_audioSource.volume = volume == -1f ? Random.Range (0.2f, 0.4f) : volume;
		_audioSource.pitch = Random.Range (0.9f, 1.1f);
		_lastPlayTime = Time.time;
	}
}
