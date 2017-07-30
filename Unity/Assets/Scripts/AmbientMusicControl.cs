
using UnityEngine;

public class AmbientMusicControl : MonoBehaviour {
	public enum eMusicOption
	{
		On,
		Off
	}

	public eMusicOption Action;

	void Start ()
	{
		GameObject ambientAudio = GameObject.Find ("AmbientAudio");

		if (ambientAudio != null)
		{
			AudioSource source = ambientAudio.GetComponent<AudioSource> ();
			switch (Action)
			{
			case eMusicOption.On:
				if (!source.isPlaying)
				{
					source.Play ();
				}
				break;
			case eMusicOption.Off:
				if (source.isPlaying)
				{
					source.Stop ();
				}
				break;
			}
		}
	}
}
