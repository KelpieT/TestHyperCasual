using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
	private float timer;
	[SerializeField] private BulletData bulletData;
	[Inject] private WeaponData weaponData;
	private void Update()
	{
		transform.localPosition += transform.rotation * Vector3.forward * bulletData.Speed * Time.deltaTime;
		timer += Time.deltaTime;
		if (timer < bulletData.TimeToDestroy) return;
		Destroy(gameObject);
	}
	private void OnTriggerEnter(Collider other)
	{
		SetDamage(other);
		Destroy(gameObject);
	}
	private void SetDamage(Collider other)
	{
		IHealth health = other.GetComponent<IHealth>();
		if (health == null) return;
		health.TakeDamage(weaponData.Damage);
	}
	public class Factory : PlaceholderFactory<WeaponData, Bullet> { }
}
