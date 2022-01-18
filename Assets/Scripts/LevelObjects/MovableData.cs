using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/MovableData")]
public class MovableData : ScriptableObject
{
	[SerializeField] private Vector3 force;

	public Vector3 Force { get => force; }
}
