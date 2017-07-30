using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseWhenActivated : MonoBehaviour
{
	public Transform Player;

	public float MaxSpeed;

	public float Acceleration;

	public float MinimumDistance;

	public float Friction = 0.9f;

	public float WaitTimeAfterDeath = 1f;

	private bool _active;

	private Vector3 _target;

	private Vector3 _velocity;

	private ChangeGameStateOnDeath _deathHandler;

	private bool _deathHandlerCalled;

	private ColActor _collision;

	void Start ()
	{
		_collision = GetComponent<ColActor> ();

		var deathObj = GameObject.Find ("DeathHandler");
		if (deathObj != null)
		{
			_deathHandler = deathObj.GetComponent<ChangeGameStateOnDeath> ();
		}
	}

	void FixedUpdate ()
	{
		float acceleration = 0f;

		if (_active)
		{
			_target = Player.position;
			acceleration = Acceleration;

			if ((_target - transform.position).magnitude < MinimumDistance)
			{
				_velocity = Vector3.zero;
				if (!_deathHandlerCalled)
				{
					StartCoroutine (DoDeath ());
				}
				return;
			}
		}
			
		Vector3 direction = (_target - transform.position).normalized;

		_velocity += direction * acceleration * Time.deltaTime;

		_velocity *= Friction;

		if (_velocity.magnitude > MaxSpeed)
		{
			_velocity = _velocity.normalized * MaxSpeed;
		}

		transform.position += _collision.ApplyCollisionToMoveVector (_velocity);
	}

	public void Activate()
	{
		_active = true;
	}

	public void Deactivate()
	{
		_active = false;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (_target, 0.25f);
	}

	private IEnumerator DoDeath ()
	{
		_deathHandlerCalled = true;

		Player.GetComponent<MoveWithKeyboard> ().enabled  = false;
		ScaryDeathEye.Play ();

		yield return new WaitForSecondsRealtime (WaitTimeAfterDeath);
		if (_deathHandler != null)
		{
			_deathHandler.ADeathHasHappened ();
		}
	}
}
