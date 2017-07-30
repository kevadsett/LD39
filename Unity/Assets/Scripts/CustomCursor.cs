using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
	private RectTransform _rectTransform;
	void Start ()
	{
		_rectTransform = GetComponent<RectTransform> ();
	}

	void Update ()
	{
		_rectTransform.position = Input.mousePosition;
	}
}
