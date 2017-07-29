
using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
	public float Speed;
	void Update ()
	{
		var move = new Vector3(Input.GetAxis("Horizontal"), transform.position.y, Input.GetAxis("Vertical"));
		transform.position += move * Speed * Time.deltaTime;
	}
}
