using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLookAtPlayer : MonoBehaviour {
	[SerializeField] Transform target;
	[SerializeField] float lookAtTime;
	[SerializeField] AnimationCurve lookAtCurve;

	float timer;
	bool shouldLookAt;

	public void Activate () {
		shouldLookAt = true;
	}

	public void Deactivate () {
		shouldLookAt = false;
	}

	void Update () {

		if (shouldLookAt) {

			Quaternion lookAt = Quaternion.LookRotation (target.position - transform.position);

			Quaternion lookAway = lookAt * Quaternion.Euler (-179f, 0f, 0f);
			Quaternion lookPretty = lookAt * Quaternion.Euler (-10f, 0f, 0f);

			transform.rotation = Quaternion.SlerpUnclamped (lookAway, lookPretty, lookAtCurve.Evaluate (timer));

			timer += Time.deltaTime / lookAtTime;

		} else {
			timer = 0f;
		}

	}
}
