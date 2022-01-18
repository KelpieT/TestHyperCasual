using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/BreakableData")]
public class BreakableData : ScriptableObject
{
	[SerializeField] private float lifeTimeAfterDeath;

	public float LifeTimeAfterDeath { get => lifeTimeAfterDeath; }
}
