using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Layer2D))]
public class Layer2DEditor : Editor
{
	Layer2D mTarget;

	private void Awake()
	{
		mTarget = (Layer2D)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Refresh")) {
			mTarget.RenewData();
		}
	}
}
