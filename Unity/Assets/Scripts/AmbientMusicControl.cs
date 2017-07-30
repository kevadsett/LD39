
using UnityEngine;

public class AmbientMusicControl : MonoBehaviour {
	public enum eMusicOption
	{
		On,
		Off
	}

	public eMusicOption Action;
	
	private const float VOLUME_CHANGE_DURATION = 1f;

	private AudioSource _source;

	private float _startTime;

	void Start ()
	{
		GameObject ambientAudio = GameObject.Find ("AmbientAudio");

		if (ambientAudio != null)
		{
			_startTime = Time.time;
			_source = ambientAudio.GetComponent<AudioSource> ();
		}
	}

	void Update()
	{
		if (_source == null)
		{
			return;
		}

		switch (Action)
		{
		case eMusicOption.On:
			if (_source.volume < 1)
			{
				_source.volume = Mathf.Clamp01 ((Time.time - _startTime) / VOLUME_CHANGE_DURATION);
			}
			break;
		case eMusicOption.Off:
			if (_source.volume > 0)
			{
				_source.volume = 1 - Mathf.Clamp01 ((Time.time - _startTime) / VOLUME_CHANGE_DURATION);
			}
			break;
		}
	}
}
