using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColVertices : MonoBehaviour {

	public static ColVertices Instance { get; private set; }

	public ColVertex[] vertices;

	void Awake () {
		Instance = this;
		vertices = GetComponentsInChildren<ColVertex> ();
	}

	public bool GetCollisionPoint (Vector3 start, Vector3 end, out Vector3 intersect, out Vector3 surface) {
		for (int i = 0; i < vertices.Length; i++) {
			if (vertices[i].GetCollisionPoint (start, end, out intersect, out surface)) {
				return true;
			}
		}

		surface = Vector3.zero;
		intersect = Vector3.zero;
		return false;
	}
}