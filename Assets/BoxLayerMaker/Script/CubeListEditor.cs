using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeList))]
public class CubeListEditor : Editor
{
	CubeList mTarget;
	Color defaultBackgroundGUIColor;

	private void Awake()
	{
		mTarget = (CubeList)target;
		defaultBackgroundGUIColor = GUI.backgroundColor;
	}

	public override void OnInspectorGUI()
	{
		// ------------------------------------------------------------------------
		// Add/remove on list
		GUILayout.BeginHorizontal();

		if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(20))) {
			mTarget.AddNewCubeType();
		}
		if (GUILayout.Button("-", GUILayout.Width(20), GUILayout.Height(20))) {
			mTarget.RemoveSelectingCubeType();
		}

		GUILayout.EndHorizontal();

		// ------------------------------------------------------------------------

		GUILayout.Space(10);

		// ------------------------------------------------------------------------
		// Display List
		for (int i = 0; i < mTarget.list.Count; i++) {

			GUILayout.BeginHorizontal();

			if (mTarget.GetSelectingTypeIndex() != i) {
				if (GUILayout.Button("o", GUILayout.Width(15), GUILayout.Height(15))) {
					mTarget.SelectType(i);
				}
			} else {
				GUILayout.Space(19);
			}

			mTarget.list[i].ID = EditorGUILayout.IntField(mTarget.list[i].ID, GUILayout.Width(50));
			GUILayout.Space(10);
			mTarget.list[i].guiColor = EditorGUILayout.ColorField(mTarget.list[i].guiColor);

			GUILayout.EndHorizontal();
		}
		// ------------------------------------------------------------------------

	}
}
