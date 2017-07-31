using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Camera))]
public class CameraCopy : MonoBehaviour {
	[SerializeField] Camera theOther;

	Camera theSelf;

	void Awake () {
		theSelf = GetComponent<Camera> ();
	}

	void Update () {
		theSelf.orthographicSize = theOther.orthographicSize;
	}
}