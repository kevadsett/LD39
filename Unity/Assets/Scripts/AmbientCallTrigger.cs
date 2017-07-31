using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientCallTrigger : MonoBehaviour
{
	private AmbientCalls _calls;

	void Start()
	{
		_calls = GameObject.Find ("AmbientCalls").GetComponent<AmbientCalls> ();
	}

	void OnTriggerEnter(Collider col)
	{
		_calls.PlaySound (1f);
	}
}
