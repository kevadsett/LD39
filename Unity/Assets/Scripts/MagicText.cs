using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicText : MonoBehaviour {
	[SerializeField] Transform player;
	[SerializeField] Color offColour;
	[SerializeField] Color onColour;
	[SerializeField] float distanceScale;
	[SerializeField] Vector3 worldOffset;

	TextMesh text;

	void Awake () {
		text = GetComponent<TextMesh> ();
	}

	void Update () {
		float distance = Vector3.Distance (transform.position, player.position + worldOffset) * distanceScale;
		text.color = Color.Lerp (onColour, offColour, distance);
	}
}