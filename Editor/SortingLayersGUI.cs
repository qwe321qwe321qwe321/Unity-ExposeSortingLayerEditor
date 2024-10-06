using System.Linq;
using UnityEditor;
using UnityEngine;

public static class SortingLayersGUI {
	public static void DrawSortingLayerSettings(Renderer renderer) {
		// https://gist.github.com/sinbad/bd0c49bc462289fa1a018ffd70d806e3
		EditorGUILayout.BeginHorizontal();
		EditorGUI.BeginChangeCheck();
		int newId = DrawSortingLayersPopup(renderer.sortingLayerID);
		if (EditorGUI.EndChangeCheck()) {
			renderer.sortingLayerID = newId;
		}

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		EditorGUI.BeginChangeCheck();
		int order = EditorGUILayout.IntField("Sorting Order", renderer.sortingOrder);
		if (EditorGUI.EndChangeCheck()) {
			renderer.sortingOrder = order;
		}

		EditorGUILayout.EndHorizontal();
	}
	
	private static int DrawSortingLayersPopup(int layerID) {
		var layers = SortingLayer.layers;
		var names = layers.Select(l => l.name).ToArray();
		if (!SortingLayer.IsValid(layerID))
		{
			layerID = layers[0].id;
		}
		var layerValue = SortingLayer.GetLayerValueFromID(layerID);
		var newLayerValue = EditorGUILayout.Popup("Sorting Layer", layerValue, names);
		return layers[newLayerValue].id;
	}

	public static class Styles {
		public static readonly GUIContent sortingLayerSettings = EditorGUIUtility.TrTextContent("Sorting Layers");
	}
}