using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Brush))]
public class BrushEditor : Editor
{
	Brush mTarget;
	Color defaultBackgroundGUIColor;

	private void Awake()
	{
		mTarget = (Brush)target;
		defaultBackgroundGUIColor = GUI.backgroundColor;
	}

	public override void OnInspectorGUI()
	{
		// ------------------------------------------------------------------------
		// Rrush Type enum dropdown

		serializedObject.Update();

		mTarget.brush = (Brush.BrushType)EditorGUILayout.EnumPopup("Brush", mTarget.brush);

		serializedObject.ApplyModifiedProperties();

		// ------------------------------------------------------------------------

		GUILayout.Space(10);

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

			if (mTarget.GetSelectingCubeTypeIndex() != i) {
				if (GUILayout.Button("o", GUILayout.Width(15), GUILayout.Height(15))) {
					mTarget.SelectCubeType(i);
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
