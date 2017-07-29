using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTexMatchCamera : MonoBehaviour {
	Camera cam;
	RenderTexture rt;

	[SerializeField] Color additiveColour;

	void Awake () {
		cam = GetComponent<Camera> ();
	}

	void Update ()  {
		if (rt == null || rt.width != Screen.width || rt.height != Screen.height) {
			rt = new RenderTexture (Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);
			cam.targetTexture = rt;
			Shader.SetGlobalTexture ("_LightBuffer", rt);
			Shader.SetGlobalColor ("_AddColor", additiveColour);
		}
	}
}
