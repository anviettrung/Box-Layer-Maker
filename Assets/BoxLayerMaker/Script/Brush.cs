using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
	[System.Serializable]
	public class CubeType
	{
		public int ID;
		public Color guiColor;

		public CubeType()
		{
			ID = 0;
			guiColor = Color.white;
		}

		public CubeType(int x)
		{
			ID = x;
			guiColor = Color.white;
		}
	}

	[System.Serializable]
	public enum BrushType
	{
		OneCube,
		OneRow,
		OneColumn
	}

	public BrushType brush;

	public List<CubeType> list = new List<CubeType>();
	protected int selectingCubeTypeIndex = 0;
	public CubeType selectingCubeType {
		get {
			return list[selectingCubeTypeIndex];
		}
	}

	public void SelectCubeType(int x)
	{
		selectingCubeTypeIndex = x;
	}

	public int GetSelectingCubeTypeIndex()
	{
		return selectingCubeTypeIndex;
	}

	public void AddNewCubeType()
	{
		list.Add(new CubeType(list.Count));
	}

	public void RemoveSelectingCubeType()
	{ 
		if (list.Count > 1) {
			list.RemoveAt(selectingCubeTypeIndex);
			if (selectingCubeTypeIndex >= list.Count)
				selectingCubeTypeIndex--;
		}
	}

	public CubeType FindCubeTypeByID(int id)
	{
		foreach (CubeType t in list) {
			if (t.ID == id)
				return t;
		}

		// Can't find so using first cube
		return list[0];
	}
}
