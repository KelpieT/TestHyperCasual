using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Player player = other.GetComponent<Player>();
		if (player != null)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		else
			Destroy(other.gameObject);
	}
}
