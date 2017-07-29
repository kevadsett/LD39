
using UnityEngine;

public class ActivateOnLit : MonoBehaviour {
	public float ArcAngle = Mathf.PI / 4;

	public float Radius = 10f;

	public Transform Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		Vector3 rads = Mathf.Deg2Rad * (Player.eulerAngles - Vector3.up * 90);

		Vector3 ArcEndPoint1 = (Radius * new Vector3 (Mathf.Cos ((ArcAngle / 2) -rads.y), 0, Mathf.Sin ((ArcAngle / 2) - rads.y)));
		Gizmos.DrawLine(Player.position, Player.position + ArcEndPoint1);

		Vector3 ArcEndPoint2 = (Radius * new Vector3 (Mathf.Cos (-rads.y - (ArcAngle / 2)), 0, Mathf.Sin (-rads.y - (ArcAngle / 2))));
		Gizmos.DrawLine(Player.position, Player.position + ArcEndPoint2);
	}
}
