
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

		Vector3 rads = Mathf.Deg2Rad * Player.eulerAngles;

		Vector3 ArcEndPoint = (Radius * new Vector3 (Mathf.Cos (-rads.y), 0, Mathf.Sin (-rads.y)));
		Gizmos.DrawLine(Player.position, Player.position + ArcEndPoint);
	}
}
