using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
	float health { get; set; }
	void TakeDamage(float damage);
	void RestoreHealth(float increaseHealth);
	void Death();
}