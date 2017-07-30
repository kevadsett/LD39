using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColActor : MonoBehaviour {

	const int MAX_ITERATIONS = 16;

	Vector3 ApplyCollisionToMoveVector (Vector3 moveVec) {
		if (ColVertices.Instance == null) {
			return moveVec;
		}

		Vector3 currentPoint = transform.position;
		Vector3 futurePoint = currentPoint + moveVec;

		Vector3 intersect, surfaceVec;

		bool collided;
		int iterations = 0;
		do {
			collided = ColVertices.Instance.GetCollisionPoint (currentPoint, futurePoint, out intersect, out surfaceVec);

			if (collided) {
				Vector3 cutOffVec = futurePoint - intersect;

				// Retain lateral momentum against line
				float conserveAmt = Vector3.Dot (surfaceVec.normalized, cutOffVec.normalized);
				Vector3 conserveVec = surfaceVec.normalized * conserveAmt * cutOffVec.magnitude;

				futurePoint = intersect + conserveVec;
			}

			if (iterations++ > MAX_ITERATIONS) {
				break;
			}

		} while (collided);

		return futurePoint - currentPoint;
	}

	void OnDrawGizmos () {

		Vector3 moveVec = transform.forward * 5f;
		Vector3 currentPoint = transform.position;

		Gizmos.color = Color.red;
		Gizmos.DrawLine (currentPoint, currentPoint + moveVec);

		Gizmos.color = Color.cyan;
		Gizmos.DrawLine (currentPoint, currentPoint + ApplyCollisionToMoveVector (moveVec));
	}
}