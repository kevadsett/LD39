using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ColVertex))]
public class ColVertexEditor : Editor {

	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();

		if (GUILayout.Button ("Create next")) {
			Debug.Log ("NEXT!");

			var colVertex = target as ColVertex;
			var xform = colVertex.transform;

			var next = Instantiate (xform.gameObject);
			next.name = "node";

			var nextxform = next.transform;
			nextxform.parent = xform;
			nextxform.localPosition = Vector3.zero;

			colVertex.next = next.GetComponent<ColVertex> ();

			Selection.activeObject = next;
		}
	}

}