
using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
	public float Speed;
	ColActor Collision;

	void Awake ()
	{
		Collision = GetComponent<ColActor> ();
	}

	void FixedUpdate ()
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), transform.position.y, Input.GetAxis("Vertical"));

		Vector3 frameMove = move * Speed * Time.deltaTime;
		Vector3 adjusted = Collision == null ? frameMove : Collision.ApplyCollisionToMoveVector (frameMove);

		transform.position += adjusted;
	}
}
