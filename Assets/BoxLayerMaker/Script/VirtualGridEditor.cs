using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VirtualGrid))]
public class VirtualGridEditor : Editor
{
	VirtualGrid mTarget;

	private void Awake()
	{
		mTarget = (VirtualGrid)target;
		//mTarget.InitData();
	}

	private void OnSceneGUI()
	{
		if (Event.current.type == EventType.MouseDown && Event.current.button == 0) {
			Vector3 mousePosition = Event.current.mousePosition;
			Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
			mousePosition = ray.origin;

			mTarget.ClickCell(mTarget.GetCoordByPosition(mousePosition));
		}
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate")) {
			mTarget.Generate();
		}
	}
}
