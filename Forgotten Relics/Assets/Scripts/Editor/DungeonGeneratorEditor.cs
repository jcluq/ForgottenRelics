using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DungeonGenerator))]
public class DungeonGeneratorEditor : Editor
{
	DungeonGenerator dg;
	void OnEnable()
	{
		dg = serializedObject.targetObject as DungeonGenerator;
	}

	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();


		GUILayout.BeginVertical();
		if (GUILayout.Button("Generate Dungeon"))
		{
			dg.Generate();
			SceneView.lastActiveSceneView.Repaint();
		}

		if (GUILayout.Button("Cellular Automata"))
		{
			dg.CellularAutomata();
			SceneView.lastActiveSceneView.Repaint();
		}

		if (GUILayout.Button("Place Objects"))
		{
			dg.PlaceObjects();
			SceneView.lastActiveSceneView.Repaint();
		}

		GUILayout.EndVertical();
	}
}
