
using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
	public float Speed;
	ColActor Collision;

	private GameDataStore _dataStore;

	void Awake ()
	{
		Collision = GetComponent<ColActor> ();
		var dataStoreObject = GameObject.Find ("DataStore");
		if (dataStoreObject != null)
		{
			_dataStore = dataStoreObject.GetComponent<GameDataStore> ();
		}
	}

	void FixedUpdate ()
	{
		bool absoluteMovement = true;
		if (_dataStore != null)
		{
			absoluteMovement = (bool)_dataStore.Store ["AbsoluteControls"];
		}

		Vector3 move;
		if (absoluteMovement)
		{
			move = new Vector3 (Input.GetAxis ("Horizontal"), transform.position.y, Input.GetAxis ("Vertical"));
		}
		else
		{
			move = transform.forward * Input.GetAxis ("Vertical") + transform.right * Input.GetAxis ("Horizontal");
		}

		Vector3 frameMove = move * Speed * Time.deltaTime;
		Vector3 adjusted = Collision == null ? frameMove : Collision.ApplyCollisionToMoveVector (frameMove);

		transform.position += adjusted;
	}
}
