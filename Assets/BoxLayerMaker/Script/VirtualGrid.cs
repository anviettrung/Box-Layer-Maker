using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;


public class VirtualGrid : MonoBehaviour
{
	public Color gridLineColor = Color.green;
	public Brush brushInfo;
	public Layer2D activeLayer;

	public Layer2D[] allLayers;

	public string exportPathFromResources;

	void OnDrawGizmos()
	{ 
		if (activeLayer == null) return;
		 
		for (int x = 0; x < activeLayer.Width; x++) {
			for (int y = 0; y < activeLayer.Height; y++) {
				Brush.CubeType t = brushInfo.FindCubeTypeByID(activeLayer.Get(x,y));
				activeLayer.Set(x, y, t.ID); // if not found then setting data to first cubetype id
				Gizmos.color = t.guiColor;
				Gizmos.DrawCube(new Vector3(x+0.5f, -y-0.5f, 0f), new Vector3(1, 1, 1));
			}
		}

		// Draw horizontal line
		for (int i = 0; i > -(activeLayer.Height + 1); i--) {
			Gizmos.color = gridLineColor;
			Gizmos.DrawLine(new Vector3(0, i, 0), new Vector3(activeLayer.Width, i, 0));
		}

		// Draw vertical line
		for (int i = 0; i < activeLayer.Width + 1; i++) {
			Gizmos.color = gridLineColor;
			Gizmos.DrawLine(new Vector3(i, 0, 0), new Vector3(i, -activeLayer.Height, 0));
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
		if (x >= activeLayer.Width || x < 0 || y >= activeLayer.Height || y < 0) 
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
		activeLayer.Set(x, y, brushInfo.selectingCubeType.ID);
	} 
	//------------------------------------------------

	public void ActionDrawOneCube(Vector2Int coord)
	{
		ActionDrawOneCube(coord.x, coord.y);
	}

	public void ActionDrawOneRow(Vector2Int coord)
	{
		for (int x = 0; x < activeLayer.Width; x++) {
			ActionDrawOneCube(x, coord.y);
		}
	}

	public void ActionDrawOneColumn(Vector2Int coord)
	{
		for (int y = 0; y < activeLayer.Height; y++) {
			ActionDrawOneCube(coord.x, y);
		}
	}

	//------------------------------------------------
	public void OnSelectLayer(Layer2D target)
	{
		// Find target in layers list
		foreach (Layer2D layer in allLayers)
			if (layer.GetInstanceID() == target.GetInstanceID()) {
				activeLayer = layer;
			}
	}


	//------------------------------------------------

	public void Export()
	{
		// using data to gen a JSON file here
		LayersDataJSON dataToExport = new LayersDataJSON(allLayers);

		string json = JsonUtility.ToJson(dataToExport);
		string path = Application.dataPath + "/Resources/" + exportPathFromResources + ".json";
		Debug.Log("AssetPath:" + path);
		File.WriteAllText(path, json);
#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
#endif

	}
}


public class LayersDataJSON
{
	[System.Serializable]
	public struct IntArray
	{
		public int[] data;
	}
	public IntArray[] layers;

	public LayersDataJSON(Layer2D[] ls)
	{
		layers = new IntArray[ls.Length];
		for (int i = 0; i < ls.Length; i++) {
			layers[i].data = ls[i].GetAll();
		}

	}
}
