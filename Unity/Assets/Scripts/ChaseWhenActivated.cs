using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseWhenActivated : MonoBehaviour
{
	public Transform Player;

	public float MaxSpeed;

	public float Acceleration;

	public float MinimumDistance;

	private bool _active;

	private Vector3 _target;

	private Vector3 _velocity;

	void Start ()
	{
		_target = transform.position;
	}

	void Update ()
	{
		if (_active)
		{
			_target = Player.position;
		}

		if ((_target - transform.position).magnitude < MinimumDistance)
		{
			_velocity = Vector3.zero;
		}
		else
		{
			Vector3 direction = (_target - transform.position).normalized;

			_velocity += direction * Acceleration * Time.deltaTime;
		}

		if (_velocity.magnitude > MaxSpeed)
		{
			_velocity = _velocity.normalized * MaxSpeed;
		}

		transform.position += _velocity;
	}

	public void Activate()
	{
		_active = true;
	}

	public void Deactivate()
	{
		_active = false;
	}
}
