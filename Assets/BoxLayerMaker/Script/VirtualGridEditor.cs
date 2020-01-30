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
			// ???
			Vector3 mousePosition = Event.current.mousePosition;
			Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
			mousePosition = ray.origin;
			Vector2Int mouseCoord = mTarget.GetCoordByPosition(mousePosition);

			if (mTarget.IsMouseInGrid(mouseCoord.x, mouseCoord.y)) {

				switch (mTarget.brushInfo.brush) {
					case Brush.BrushType.OneCube:
						mTarget.ActionDrawOneCube(mouseCoord);
						break;
					case Brush.BrushType.OneRow:
						mTarget.ActionDrawOneRow(mouseCoord);
						break;
					case Brush.BrushType.OneColumn:
						mTarget.ActionDrawOneColumn(mouseCoord);
						break;
				}
			}
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
