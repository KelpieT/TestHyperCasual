using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Player : MonoBehaviour
{
	[Inject] private IController controller;
	private IWeapon weapon;
	[Inject] private Gun.Factory gunFactory;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private PlayerData playerData;
	[SerializeField] private Transform weaponSpawnPoint;
	private bool isStoped;

	private Vector3 lastPosition;

	private void Start()
	{
		controller.onMoveFixed += OnMove;//Chose fixed because work with rigitbody
		controller.onStop += OnStop;
		InitWeapon();
	}

	private void InitWeapon()
	{
		Weapon _weapon = gunFactory.Create();
		_weapon.transform.parent = weaponSpawnPoint;
		_weapon.transform.localPosition = Vector3.zero;
		_weapon.transform.localRotation = Quaternion.identity;
		weapon = _weapon;
	}

	private void OnMove(Vector2 normalizedVector)
	{
		isStoped = false;
		weapon.ResetWeapon();
		Vector3 _normalizedVector = new Vector3(normalizedVector.x, 0, normalizedVector.y);
		lastPosition = transform.position;
		Vector3 velocityDirection = _normalizedVector * playerData.MoveSpeed;
		rb.velocity = velocityDirection + new Vector3(0, rb.velocity.y, 0);
		Rotate(_normalizedVector);
	}
	private void Rotate(Vector3 normalizedVector)
	{
		if (normalizedVector.magnitude < playerData.DeadZoneForRotation) return;
		float yAngle = Vector3.SignedAngle(Vector3.forward, normalizedVector, Vector3.up);
		transform.rotation = Quaternion.Euler(0, yAngle, 0);
	}
	private void Update()
	{
		if (isStoped) weapon?.UpdateWeapon();
	}
	private void OnCollisionEnter(Collision collision)
	{
		CollisionWithMovable(collision.collider);
		CollisionWithPickable(collision.collider);
	}
	private void CollisionWithMovable(Collider collider)
	{
		IMovable movable = collider.GetComponent<IMovable>();
		if (movable == null) return;
		Vector3 direction = collider.transform.position - transform.position;
		direction = new Vector3(direction.x, 0, direction.y).normalized;
		movable.Move(direction);
	}
	private void CollisionWithPickable(Collider collider)
	{
		IPickable pickable = collider.GetComponent<IPickable>();
		if (pickable == null) return;
		pickable.PickUp();
	}

	private void OnStop()
	{
		rb.velocity = new Vector3(0, rb.velocity.y, 0);
		isStoped = true;

	}
	private void OnDestroy()
	{
		controller.onMoveFixed -= OnMove;
		controller.onStop -= OnStop;
	}

}
