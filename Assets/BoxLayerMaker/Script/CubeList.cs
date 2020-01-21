using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeList : MonoBehaviour
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

	public List<CubeType> list = new List<CubeType>();
	protected int selectingTypeIndex = 0;
	public CubeType selectingCubeType {
		get {
			return list[selectingTypeIndex];
		}
	}

	public void SelectType(int x)
	{
		selectingTypeIndex = x;
	}

	public int GetSelectingTypeIndex()
	{
		return selectingTypeIndex;
	}

	public void AddNewCubeType()
	{
		list.Add(new CubeType(list.Count));
	}

	public void RemoveSelectingCubeType()
	{ 
		if (list.Count > 1) {
			list.RemoveAt(selectingTypeIndex);
			if (selectingTypeIndex >= list.Count)
				selectingTypeIndex--;
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
