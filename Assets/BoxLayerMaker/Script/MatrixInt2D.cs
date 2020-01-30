using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixInt2D : MonoBehaviour
{
	public int[,] data;
	 
	public void RenewData()
	{
		data = new int[20, 20];
	}

	public int Height {
		get {
			return data.GetLength(0);
		}
	}

	public int Width {
		get {
			return data.GetLength(1);
		}
	}
}
