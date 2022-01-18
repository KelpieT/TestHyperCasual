using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Pickable : MonoBehaviour, IPickable
{
	[SerializeField] private PickableData pickableData;
	public void PickUp()
	{
		Debug.Log("Pickup money " + pickableData.CountItem.ToString());
		Destroy(gameObject);
	}
	private void Update()
	{
		float yAngle = transform.rotation.eulerAngles.y + pickableData.RotaionSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, yAngle, 0);
	}
	public class Factory : PlaceholderFactory<Pickable> { }
}
