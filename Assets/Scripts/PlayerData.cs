using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/PlayerData")]
public class PlayerData : ScriptableObject
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float deadZoneForRotation = 0.01f;

	public float MoveSpeed { get => moveSpeed; }
	public float DeadZoneForRotation { get => deadZoneForRotation; }
}
