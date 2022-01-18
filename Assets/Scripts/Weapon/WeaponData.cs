using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/WeaponData")]
public class WeaponData : ScriptableObject
{
	[SerializeField] private float timeBetweenAttack;
	[SerializeField] private float damage;
	[SerializeField] private bool infinityAttack;
	[SerializeField] private int countAttacks;
	public float TimeBetweenAttack { get => timeBetweenAttack; }
	public float Damage { get => damage; }
	public int CountAttacks { get => countAttacks; }
	public bool InfinityAttack { get => infinityAttack; }
}
