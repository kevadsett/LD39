
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform Player;

	public float SmoothTime;

	public float LookAhead = 10f;

	private Vector3 _velocity;

	private float _startY;

	private Vector3 _targetPoint;

	void Start()
	{
		_startY = transform.position.y;
	}

	void Update ()
	{
		var rotation = Mathf.Deg2Rad * (Player.rotation.eulerAngles - Vector3.up * 90);
		_targetPoint = Player.position + new Vector3 (Mathf.Cos (-rotation.y), 0, Mathf.Sin (-rotation.y)) * LookAhead;
		_targetPoint.y = _startY;

		transform.position = Vector3.SmoothDamp (transform.position, _targetPoint, ref _velocity, SmoothTime);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawSphere (_targetPoint, 1);
	}
}
