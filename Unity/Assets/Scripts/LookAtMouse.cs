﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
	public float speed;

	private Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void FixedUpdate () 
	{
		Plane playerPlane = new Plane(Vector3.up, transform.position);

		Ray ray = cam.ScreenPointToRay (Input.mousePosition);

		float hitdist = 0.0f;
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}
	}
}
