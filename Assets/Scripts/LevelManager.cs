using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class LevelManager : MonoBehaviour
{
	[SerializeField] private LevelData levelData;
	[Inject] Movable.Factory movableFactory;
	[Inject] Breakable.Factory breakableFactory;
	[Inject] Pickable.Factory pickableFactory;
	private void Awake()
	{
		transform.localScale = levelData.LevelSize;
		List<Vector3> points = levelData.PointsForSpawn();
		foreach (Vector3 p in points)
		{
			GameObject g = SpawnObject();
			if (g == null) continue;
			g.transform.position = p;
			g.transform.rotation = Quaternion.Euler(0, Random.Range(0, 359f), 0);
		}
	}
	public GameObject SpawnObject()
	{
		float total = levelData.ChanceSpawnEmpty
			+ levelData.ChanceSpawnBreakable
			+ levelData.ChanceSpawnMovable
			+ levelData.ChanceSpawnPickable;
		float random = Random.Range(0, total);
		if (random < levelData.ChanceSpawnEmpty)
			return null;
		else if (random < levelData.ChanceSpawnEmpty + levelData.ChanceSpawnBreakable)
			return breakableFactory.Create().gameObject;
		else if (random < levelData.ChanceSpawnEmpty + levelData.ChanceSpawnBreakable + levelData.ChanceSpawnMovable)
			return movableFactory.Create().gameObject;
		else
			return pickableFactory.Create().gameObject;
	}


}
