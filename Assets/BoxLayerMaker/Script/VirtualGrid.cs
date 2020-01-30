using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGrid : MonoBehaviour
{
	public Color gridLineColor = Color.green;
	public Brush brushInfo;

	public MatrixInt2D matrix;

	void OnDrawGizmos()
	{
		if (matrix == null) return;
		 
		for (int x = 0; x < matrix.Width; x++) {
			for (int y = 0; y < matrix.Height; y++) {
				Brush.CubeType t = brushInfo.FindCubeTypeByID(matrix.data[x,y]);
				matrix.data[x, y] = t.ID; // if not found then setting data to first cubetype id
				Gizmos.color = t.guiColor;
				Gizmos.DrawCube(new Vector3(x+0.5f, -y-0.5f, 0f), new Vector3(1, 1, 1));
			}
		}

		// Draw horizontal line
		for (int i = 0; i > -(matrix.Height + 1); i--) {
			Gizmos.color = gridLineColor;
			Gizmos.DrawLine(new Vector3(0, i, 0), new Vector3(matrix.Width, i, 0));
		}

		// Draw vertical line
		for (int i = 0; i < matrix.Width + 1; i++) {
			Gizmos.color = gridLineColor;
			Gizmos.DrawLine(new Vector3(i, 0, 0), new Vector3(i, -matrix.Height, 0));
		}
	}

	public Vector2Int GetCoordByPosition(Vector2 position)
	{
		int x = Mathf.FloorToInt(position.x);
		int y = Mathf.FloorToInt(-position.y);

		return new Vector2Int(x, y);
	}

	public bool IsMouseInGrid(int x, int y)
	{
		if (x >= matrix.Width || x < 0 || y >= matrix.Height || y < 0) 
			return false;
		   
		return true;
	}

	/// <summary>
	/// Actions the draw one cube (BASE FUNCTION)
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void ActionDrawOneCube(int x, int y)
	{
		matrix.data[x, y] = brushInfo.selectingCubeType.ID;
	}
	//------------------------------------------------

	public void ActionDrawOneCube(Vector2Int coord)
	{
		ActionDrawOneCube(coord.x, coord.y);
	}

	public void ActionDrawOneRow(Vector2Int coord)
	{
		for (int x = 0; x < matrix.Width; x++) {
			ActionDrawOneCube(x, coord.y);
		}
	}

	public void ActionDrawOneColumn(Vector2Int coord)
	{
		for (int y = 0; y < matrix.Height; y++) {
			ActionDrawOneCube(coord.x, y);
		}
	}

	public void Generate()
	{
		// using data to gen a JSON file here

		Debug.Log("Generate: haven't implement yet!");
	}
}
