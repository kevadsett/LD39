using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour
{
	public Transform Exit;

	public Transform Player;

	private Text _text;

	void Start ()
	{
		_text = GetComponent<Text> ();
	}

	void Update ()
	{
		int distance = Mathf.RoundToInt((Exit.position - Player.position).magnitude);
		_text.text = string.Format ("Distance to exit: {0}m", distance);
	}
}
