using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Gun : Weapon
{
	[Inject] private Player player;
	[Inject] private Bullet.Factory bulletFactory;
	[SerializeField] private Transform spawnPointProjectile;

	protected override void Attack()
	{
		
		Bullet _bullet = bulletFactory.Create(weaponData);
		_bullet.transform.position = spawnPointProjectile.position;
		_bullet.transform.rotation = spawnPointProjectile.rotation;
	}
	private void Update()
	{
		RotateToTarget();
	}

	private void RotateToTarget()
	{
		Vector3 direction = player.transform.rotation * Vector3.forward;
		Vector3 startPointRay = player.transform.position + direction;
		Ray ray = new Ray(startPointRay, direction);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			transform.LookAt(hit.point);
		}
		else
		{
			transform.localRotation = Quaternion.identity;
		}
	}
	public class Factory : PlaceholderFactory<Gun> { }
}
