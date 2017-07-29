
using UnityEngine;

public class ActivateOnLit : MonoBehaviour {
	public float ArcAngle = Mathf.PI / 4;

	public float Radius = 10f;

	public Transform Player;

	private float _antiClockwiseBoundary;
	private float _clockwiseBoundary;

	public bool _isInView;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 deltaPos = new Vector3 (transform.position.x - Player.position.x, 0, transform.position.z - Player.position.z);

		Vector3 rads = Mathf.Deg2Rad * (Player.eulerAngles - Vector3.up * 90);

		_antiClockwiseBoundary = (ArcAngle / 2) - rads.y;
		_clockwiseBoundary = -(ArcAngle / 2) - rads.y;

		Vector3 coneEdgeVector = new Vector3 (Mathf.Cos (_antiClockwiseBoundary), 0, Mathf.Sin (_antiClockwiseBoundary));

		Vector3 playerForward = Player.forward;

		_isInView = Vector3.Dot (coneEdgeVector, playerForward) < Vector3.Dot (deltaPos.normalized, playerForward);

		_isInView &= deltaPos.magnitude < Radius;
	}

	void OnDrawGizmos()
	{
		if (_isInView)
		{
			Gizmos.color = Color.green;
		}
		else
		{
			Gizmos.color = Color.yellow;
		}

		Vector3 ArcEndPoint1 = (Radius * new Vector3 (Mathf.Cos (_antiClockwiseBoundary), 0, Mathf.Sin (_antiClockwiseBoundary)));
		Gizmos.DrawLine(Player.position, Player.position + ArcEndPoint1);

		Vector3 ArcEndPoint2 = (Radius * new Vector3 (Mathf.Cos (_clockwiseBoundary), 0, Mathf.Sin (_clockwiseBoundary)));
		Gizmos.DrawLine(Player.position, Player.position + ArcEndPoint2);
	}
}
