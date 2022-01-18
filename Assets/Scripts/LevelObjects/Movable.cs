
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Movable : MonoBehaviour, IMovable
{
	[SerializeField] private MovableData movableData;
	[SerializeField] private Rigidbody rb;
	private Vector3 direction;
	private bool isMoving;
	public void Move(Vector3 direction)
	{
		this.direction = direction;
		isMoving = true;
	}
	private void FixedUpdate()
	{
		if (!isMoving) return;
		Vector3 _force = direction * movableData.Force.z + new Vector3(0, movableData.Force.y, 0);
		rb.AddForce(_force, ForceMode.Impulse);
		isMoving = false;
	}
	public class Factory : PlaceholderFactory<Movable> { }

}
