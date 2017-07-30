using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameStateOnDeath : MonoBehaviour
{
	private GameStateMachine _gameStateMachine;

	void Start ()
	{
		_gameStateMachine = GameObject.Find ("GameStateMachine").GetComponent<GameStateMachine> ();
	}

	public void ADeathHasHappened()
	{
		_gameStateMachine.ChangeState (GameStateMachine.eGameState.Lose);
	}
}
