using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Breakable : MonoBehaviour, IHealth
{
	[SerializeField] private List<Rigidbody> rigidbodies;
	[SerializeField] private BreakableData breakableData;
	public float health { get; set; }

	public void Death()
	{
		foreach (Rigidbody rb in rigidbodies)
		{
			rb.isKinematic = false;
		}
		Invoke(nameof(DestroyThis), breakableData.LifeTimeAfterDeath);
	}
	void DestroyThis()
	{
		Destroy(gameObject);
	}

	public void RestoreHealth(float increaseHealth)
	{
		health += increaseHealth;
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0) Death();
	}
	public class Factory : PlaceholderFactory<Breakable> { }
}
