using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColVertex : MonoBehaviour {

	public ColVertex next;

	void Awake () {

	}

	public bool GetCollisionPoint (Vector3 start, Vector3 end, out Vector3 intersect, out Vector3 surface) {
		if (next == null) {
			surface = Vector3.zero;
			intersect = Vector3.zero;
			return false;
		}

		surface = next.transform.position - transform.position;

		return LineIntersection.Get (transform.position, next.transform.position, start, end, out intersect);
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, 1f);

		if (next != null) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine (transform.position, next.transform.position);
		}
	}
}