using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TestHC/CameraData")]
public class CameraData : ScriptableObject
{
	[SerializeField] private Vector3 cameraFollowPositionOffset;
	[SerializeField] private float speed = 10f;
	public Vector3 CameraFollowPositionOffset { get => cameraFollowPositionOffset; }
	public float Speed { get => speed; }
}
