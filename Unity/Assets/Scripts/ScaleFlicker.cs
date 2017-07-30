using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFlicker : MonoBehaviour {
	[SerializeField] float amount;
	[SerializeField] float freq;

	float timer;

	void Update () {
		timer += Time.deltaTime;

		if (timer > freq) {
			transform.localScale = Vector3.one * (1f - Random.Range (0f, amount));
		}
	}
}