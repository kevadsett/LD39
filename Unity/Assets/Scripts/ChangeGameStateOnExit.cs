using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameStateOnExit : MonoBehaviour
{
	private GameStateMachine _gameStateMachine;

	void Start ()
	{
		_gameStateMachine = GameObject.Find ("GameStateMachine").GetComponent<GameStateMachine> ();
	}

	public void WellDoneYouWon()
	{
		_gameStateMachine.ChangeState (GameStateMachine.eGameState.Win);
	}
}
