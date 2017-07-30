using System.Collections;
using UnityEngine;

public class PlayerExitCollisionDetection : MonoBehaviour {
	public float WaitTimeAfterExit = 1f;

	private ChangeGameStateOnExit _exitHandler;

	private bool _exitHandlerCalled;

	void Start ()
	{
		_exitHandler = GameObject.Find ("ExitHandler").GetComponent<ChangeGameStateOnExit> ();
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision);

		if (LayerMask.LayerToName (collision.collider.gameObject.layer) != "Player")
		{
			return;
		}

		if (!_exitHandlerCalled)
		{
			StartCoroutine (DoExit ());
		}
	}

	private IEnumerator DoExit ()
	{
		_exitHandlerCalled = true;
		yield return new WaitForSeconds (WaitTimeAfterExit);
		_exitHandler.WellDoneYouWon ();
	}
}
