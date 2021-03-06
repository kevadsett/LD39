﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainOnAnyKey : MonoBehaviour {
	private GameStateMachine _gameStateMachine;

	void Start ()
	{
		_gameStateMachine = GameObject.Find ("GameStateMachine").GetComponent<GameStateMachine> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_gameStateMachine.ChangeState (GameStateMachine.eGameState.Main);
		}
	}
}
