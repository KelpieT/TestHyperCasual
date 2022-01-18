using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/PickableData")]
public class PickableData : ScriptableObject
{
	[SerializeField] private int countItem;
	[SerializeField] float rotaionSpeed;
	public int CountItem { get => countItem; }
	public float RotaionSpeed { get => rotaionSpeed; }
}
