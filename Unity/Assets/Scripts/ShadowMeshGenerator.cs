using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMeshGenerator : MonoBehaviour
{
	public Transform Player;

	public Transform LevelQuads;

	public float Size = 100f;
	
	private List<MeshFilter> _obstacles;

	private MeshFilter _meshFilter;

	private List<Vector3> _obstacleVertices = new List<Vector3> ();

	void Start ()
	{
		_meshFilter = GetComponent<MeshFilter> ();

		_obstacles = new List<MeshFilter> ();
		foreach (Transform child in LevelQuads)
		{
			_obstacles.Add (child.gameObject.GetComponent<MeshFilter> ());
		}

		foreach (MeshFilter obstacleMeshFilter in _obstacles)
		{
			Mesh obstacleMesh = obstacleMeshFilter.mesh;

			for (int i = 0; i < obstacleMesh.vertices.Length; i++)
			{
				_obstacleVertices.Add (obstacleMeshFilter.transform.TransformPoint (obstacleMesh.vertices [i]));
			}
		}
	}

	private void createShadowMesh ()
	{
		Mesh mesh = _meshFilter.mesh;

		List<Vector3> vertices = new List<Vector3> ();
		List<int> triangles = new List<int> ();

		for (int i = 0; i < _obstacleVertices.Count; i++)
		{
			var vertex = _obstacleVertices [i];

			Vector3 direction = Vector3.Normalize (vertex - Player.position);

			vertices.Add (vertex);
			vertices.Add (vertex + Vector3.Scale (direction, new Vector3 (Size, Size, Size)));
		}

		for (int i = 0, vertsPerObstacle = vertices.Count / _obstacles.Count; i < _obstacles.Count * vertsPerObstacle; i+= vertsPerObstacle)
		{
			triangles.Add (i);		
			triangles.Add (i + 1);	
			triangles.Add (i + 6);	
			triangles.Add (i + 6);	
			triangles.Add (i + 1);	
			triangles.Add (i + 7); 	
			triangles.Add (i + 6); 	
			triangles.Add (i + 7);	
			triangles.Add (i + 3);	
			triangles.Add (i + 6); 	
			triangles.Add (i + 3);	
			triangles.Add (i + 2); 	
			triangles.Add (i + 2); 	
			triangles.Add (i + 3); 	
			triangles.Add (i + 5);	
			triangles.Add (i + 2); 	
			triangles.Add (i + 5); 	
			triangles.Add (i + 4);	
		}

		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
	}
	
	void Update ()
	{
		createShadowMesh ();
	}
}
