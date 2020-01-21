using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGrid : MonoBehaviour
{
	[HideInInspector]
	public int WIDTH  = 20;
	[HideInInspector]
	public int HEIGHT = 20;
	public Color lineColor = Color.green;
	public CubeList usingList;

	public int[,] data = new int[20, 20];

	void OnDrawGizmos()
	{
		for (int x = 0; x < WIDTH; x++) {
			for (int y = 0; y < HEIGHT; y++) {
				CubeList.CubeType t = usingList.FindCubeTypeByID(data[x,y]);
				data[x, y] = t.ID; // if not found then setting data to first cubetype id
				Gizmos.color = t.guiColor;
				Gizmos.DrawCube(new Vector3(x+0.5f, -y-0.5f, 0f), new Vector3(1, 1, 1));
			}
		}

		// Draw horizontal line
		for (int i = 0; i > -(HEIGHT + 1); i--) {
			Gizmos.color = lineColor;
			Gizmos.DrawLine(new Vector3(0, i, 0), new Vector3(WIDTH, i, 0));
		}

		// Draw vertical line
		for (int i = 0; i < WIDTH + 1; i++) {
			Gizmos.color = lineColor;
			Gizmos.DrawLine(new Vector3(i, 0, 0), new Vector3(i, -HEIGHT, 0));
		}
	}

	public void ClickCell(Vector2Int coord)
	{
		data[coord.x, coord.y] = usingList.selectingCubeType.ID;
	}

	public Vector2Int GetCoordByPosition(Vector2 position)
	{
		int x = Mathf.FloorToInt(position.x);
		int y = Mathf.FloorToInt(-position.y);

		return new Vector2Int(x, y);
	}

	public void Generate()
	{
		// using data to gen a JSON file here

		Debug.Log("Generate");
	}
}
