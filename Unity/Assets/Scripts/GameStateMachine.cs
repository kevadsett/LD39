﻿using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour {
	public enum eGameState
	{
		Splash,
		Main,
		Lose,
		Win
	}

	private Dictionary<eGameState, SceneLoader> _stateScenes;

	private SceneLoader currentStateScene;

	void Start ()
	{
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (GameObject.Find("AmbientAudio"));
		DontDestroyOnLoad (GameObject.Find("DataStore"));
		_stateScenes = new Dictionary<eGameState, SceneLoader>
		{
			{ eGameState.Splash, new SceneLoader("Splash") },
			{ eGameState.Main, new SceneLoader("main") },
			{ eGameState.Win, new SceneLoader("Win") },
			{ eGameState.Lose, new SceneLoader("Lose") },
		};

		ChangeState (eGameState.Splash);
	}

	public void ChangeState(eGameState newState)
	{
		if (currentStateScene != null)
		{
			currentStateScene.OnExit ();
		}

		// cursor hack
		Cursor.visible = (newState != eGameState.Main);

		currentStateScene = _stateScenes [newState];
		currentStateScene.OnEnter ();
	}
}
