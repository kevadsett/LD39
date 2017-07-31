using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Camera))]
public class MagicCamera : MonoBehaviour {
	[SerializeField] float maxZoom;
	[SerializeField] float minZoom;
	[SerializeField] float timeScaleIn;
	[SerializeField] float timeScaleOut;
	[SerializeField] AnimationCurve curve;

	float timer;
	Camera cam;

	static bool enemyIsVisible;

	public static void TellEnemyIsVisible () {
		enemyIsVisible = true;
	}

	void Awake () {
		cam = GetComponent<Camera> ();
	}

	void LateUpdate () {

		if (enemyIsVisible) {
			timer = Mathf.Clamp01 (timer + timeScaleIn * Time.deltaTime);
		} else {
			timer = Mathf.Clamp01 (timer - timeScaleOut * Time.deltaTime);
		}

		cam.orthographicSize = Mathf.Lerp (minZoom, maxZoom, curve.Evaluate (timer));

		enemyIsVisible = false;
	}
}