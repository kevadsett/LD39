using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMesh : MonoBehaviour {

	[SerializeField] int gridWidth;
	[SerializeField] int gridHeight;
	[SerializeField] float minSize;
	[SerializeField] float maxSize;
	[SerializeField] float offset;
	[SerializeField] float rand;

	void Awake () {
		Vector3[] verts = new Vector3[gridWidth * gridHeight * 4];
		int[] tris = new int[gridWidth * gridHeight * 6];

		int v = 0;
		int t = 0;

		for (int x = 0; x < gridWidth; x++) {
			for (int z = 0; z < gridHeight; z++) {
				Vector3 centre = new Vector3 (x + Random.Range (-rand, rand), 0, z + Random.Range (-rand, rand));
				float rad = Random.Range (minSize, maxSize) * 0.5f;

				int sv = v;

				verts[v++] = new Vector3 (centre.x - rad + Random.Range (-offset, offset), 0f, centre.z - rad + Random.Range (-offset, offset));
				verts[v++] = new Vector3 (centre.x + rad + Random.Range (-offset, offset), 0f, centre.z - rad + Random.Range (-offset, offset));
				verts[v++] = new Vector3 (centre.x + rad + Random.Range (-offset, offset), 0f, centre.z + rad + Random.Range (-offset, offset));
				verts[v++] = new Vector3 (centre.x - rad + Random.Range (-offset, offset), 0f, centre.z + rad + Random.Range (-offset, offset));

				tris[t++] = sv + 0; tris[t++] = sv + 2; tris[t++] = sv + 1;
				tris[t++] = sv + 2; tris[t++] = sv + 0; tris[t++] = sv + 3;
			}
		}

		Mesh newMesh = new Mesh ();
		newMesh.vertices = verts;
		newMesh.triangles = tris;
		newMesh.RecalculateBounds ();

		GetComponent<MeshFilter> ().sharedMesh = newMesh;
	}
}