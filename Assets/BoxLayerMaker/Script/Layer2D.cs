using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer2D : MonoBehaviour
{
	[SerializeField]
	protected int[] data;
	protected int height;
	protected int width;

	[SerializeField]
	private int defaultHeight = 20;
	[SerializeField]
	private int defaultWidth = 20;

	public Layer2D()
	{
		RenewData(); 
	}

	public Layer2D(int w, int h)
	{
		RenewData(w, h);
	}

	public void RenewData(int w, int h)
	{
		width = w;
		height = h;
		data = new int[w * h];
	}

	public void RenewData()
	{
		RenewData(defaultWidth, defaultHeight);
	}

	public int[] GetAll()
	{
		return data;
	}

	public int Get(int x, int y)
	{
		if ((height - y - 1) * width + x < width * height)
			return data[(height - y - 1) * width + x];

		return 0;
	}

	public void Set(int x, int y, int value)
	{
		if ((height - y - 1) * width + x < width * height)
			data[(height-y-1)*width + x] = value;
	}

	public int Height {
		get {
			return height;
		}
	}

	public int Width {
		get {
			return width;
		}
	}
}
