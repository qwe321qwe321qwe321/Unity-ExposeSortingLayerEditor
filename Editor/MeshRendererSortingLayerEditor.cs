using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshRenderer))]
internal class MeshRendererSortingEditor : MeshRendererEditor {
	private SavedBool m_ShowSortingLayerSettings;
	public override void OnEnable() {
		base.OnEnable();
		m_ShowSortingLayerSettings = new SavedBool($"{target.GetType()}.ShowProbeSettings", true);
	}
	
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		MeshRenderer renderer = target as MeshRenderer;
		if (renderer == null) return;

		m_ShowSortingLayerSettings.value = EditorGUILayout.BeginFoldoutHeaderGroup(m_ShowSortingLayerSettings.value, SortingLayersGUI.Styles.sortingLayerSettings);
		if (m_ShowSortingLayerSettings.value)
		{
			++EditorGUI.indentLevel;
			SortingLayersGUI.DrawSortingLayerSettings(renderer);
			--EditorGUI.indentLevel;
		}
		EditorGUILayout.EndFoldoutHeaderGroup();
	}

}