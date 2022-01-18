using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/BulletData")]
public class BulletData : ScriptableObject
{
	[SerializeField] private float timeToDestroy;
	[SerializeField] private float speed;
	public float TimeToDestroy { get => timeToDestroy; }
	public float Speed { get => speed;  }
}
