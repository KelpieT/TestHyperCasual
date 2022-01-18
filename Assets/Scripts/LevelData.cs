using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[CreateAssetMenu(menuName = "TestHC/LevelData")]
public class LevelData : ScriptableObject
{
	[SerializeField] private float levelSize;
	[SerializeField] private float gridSize;

	[SerializeField] [Range(0f,100f)] private float randomGrid;
	[SerializeField] private float chanceSpawnEmpty;
	[SerializeField] private float chanceSpawnBreakable;
	[SerializeField] private float chanceSpawnMovable;
	[SerializeField] private float chanceSpawnPickable;

	public Vector3 LevelSize { get => new Vector3(levelSize, levelSize, 1); }
	public float ChanceSpawnEmpty { get => chanceSpawnEmpty; }
	public float ChanceSpawnBreakable { get => chanceSpawnBreakable; }
	public float ChanceSpawnMovable { get => chanceSpawnMovable; }
	public float ChanceSpawnPickable { get => chanceSpawnPickable; }

	public List<Vector3> PointsForSpawn()
	{
		List<Vector3> points = new List<Vector3>();
		float step = levelSize * 2 / gridSize;
		int countInGrid = (int)step;
		for (int i = 0; i < countInGrid; i++)
		{
			float x = gridSize * i - levelSize;
			float randX = RandomOffsetGrid();
			for (int j = 0; j < countInGrid; j++)
			{
				float z = gridSize * j - levelSize;
				float randZ = RandomOffsetGrid();
				Vector3 v = new Vector3(x + randX, 0, z + randZ);
				if (v.magnitude < levelSize)
				{
					points.Add(v);
				}
			}
		}
		return points;
	}
	private float RandomOffsetGrid()
	{
		return gridSize * ((Random.Range(0f, randomGrid) - randomGrid / 2)) / 100f;
	}
}
