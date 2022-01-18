using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class CameraController : MonoBehaviour
{
	[SerializeField] private CameraData cameraData;
	[Inject] private Player player;
	private Vector3 smoothDampVelocity;

	private void LateUpdate()
	{
		float smoothTime = 1 / cameraData.Speed;
		transform.position = Vector3.SmoothDamp(transform.position, player.transform.position - cameraData.CameraFollowPositionOffset, ref smoothDampVelocity, smoothTime);
		transform.LookAt(player.transform);
	}
}
