using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryDeathEye : MonoBehaviour {
	[SerializeField] float maxScale;
	[SerializeField] float duration;
	[SerializeField] AnimationCurve curve;

	bool isActive;
	float timer;

	static ScaryDeathEye instance;

	public static void Play () {
		if (instance != null) {
			instance.PlayMe ();
		}
	}

	void PlayMe () {
		isActive = true;
		timer = 0f;
	}

	void Awake () {
		instance = this;
	}

	void Update () {
		if (isActive) {
			timer += Time.deltaTime;

			float amt = curve.Evaluate (timer / duration) * maxScale;
			transform.localScale = new Vector3 (amt, 0.1f, amt);
		}
	}
}