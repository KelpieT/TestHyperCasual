using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
	[SerializeField] protected WeaponData weaponData;
	private float timer;
	private int countAttacks;
	protected abstract void Attack();
	public void UpdateWeapon()
	{
		if (countAttacks == 0)
		{
			Attack();
			countAttacks++;
		}
		timer += Time.deltaTime;
		if (timer < weaponData.TimeBetweenAttack) return;
		countAttacks++;
		if (!weaponData.InfinityAttack && countAttacks >= weaponData.CountAttacks) return;
		Attack();
		timer = 0;
	}
	public void ResetWeapon()
	{
		timer = 0;
		countAttacks = 0;
	}
}
