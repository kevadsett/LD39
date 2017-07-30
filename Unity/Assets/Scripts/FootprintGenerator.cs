using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintGenerator : MonoBehaviour
{
	public GameObject FootprintPrefab;

	public Transform Player;

	public float DistancePerFootprint;

	public float Width;

	public List<AudioClip> FootstepSounds;
	public List<AudioClip> UnusedSounds;

	private float _distanceTravelled;

	private Vector3 _positionLastFrame;

	private List<GameObject> _footprints = new List<GameObject>();

	private bool _isLeft;

	private AudioSource _leftSource;
	private AudioSource _rightSource;

	void Start ()
	{
		_leftSource = gameObject.AddComponent<AudioSource> ();
		_rightSource = gameObject.AddComponent<AudioSource> ();

		_leftSource.volume = _rightSource.volume = 0.05f;

		ResetUnusedSounds ();
	}

	void Update ()
	{
		Vector3 currentPosition = Player.position;

		_distanceTravelled += (currentPosition - _positionLastFrame).magnitude;

		_positionLastFrame = Player.position;

		if (_distanceTravelled >= DistancePerFootprint)
		{
			_distanceTravelled -= DistancePerFootprint;
			GenerateFootprint ();
		}
	}

	private void GenerateFootprint()
	{
		_isLeft = !_isLeft;

		GameObject newFootprint = GameObject.Instantiate (FootprintPrefab);

		Vector3 newPosition = Player.position;

		newPosition += (_isLeft ? -1 : 1) * Player.right * Width;

		newFootprint.transform.position = newPosition;

		newFootprint.transform.rotation = Quaternion.Euler(90, Player.rotation.eulerAngles.y, 0);

		newFootprint.transform.SetParent (transform);

		_footprints.Add (newFootprint);

		PlayFootstep ();
	}

	private void PlayFootstep()
	{
		if (UnusedSounds.Count == 0)
		{
			ResetUnusedSounds ();
		}

		AudioClip nextSound = UnusedSounds [Random.Range (0, UnusedSounds.Count)];
		UnusedSounds.Remove (nextSound);
		if (_isLeft)
		{
			_leftSource.clip = nextSound;
			_leftSource.pitch = Random.Range (0.9f, 1.1f);
			_leftSource.Play ();
		}
		else
		{
			_rightSource.clip = nextSound;
			_rightSource.pitch = Random.Range (0.9f, 1.1f);
			_rightSource.Play ();
		}
	}

	private void ResetUnusedSounds()
	{
		foreach (AudioClip sound in FootstepSounds)
		{
			UnusedSounds.Add (sound);
		}
	}
}
