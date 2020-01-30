using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MatrixInt2D))]
public class MatrixInt2DEditor : Editor
{
	MatrixInt2D mTarget;

	private void Awake()
	{
		mTarget = (MatrixInt2D)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Refresh")) {
			mTarget.RenewData();
		}
	}
}
