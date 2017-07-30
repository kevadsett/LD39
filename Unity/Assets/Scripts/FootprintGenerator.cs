using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintGenerator : MonoBehaviour
{
	public GameObject FootprintPrefab;

	public Transform Player;

	public float DistancePerFootprint;

	public float Width;

	private float _distanceTravelled;

	private Vector3 _positionLastFrame;

	private List<GameObject> _footprints = new List<GameObject>();

	private bool _isLeft;

	void Start ()
	{
		
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
	}
}
