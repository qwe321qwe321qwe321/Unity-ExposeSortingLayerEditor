using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkinnedMeshRenderer))]
[CanEditMultipleObjects]
internal class SkinnedMeshRendererSortingEditor : SkinnedMeshRendererEditor {
	private SavedBool m_ShowSortingLayerSettings;
	private SerializedProperty m_SortingLayerIdProperty;
	private SerializedProperty m_SortingOrderProperty;
	public override void OnEnable() {
		base.OnEnable();
		m_ShowSortingLayerSettings = new SavedBool($"{target.GetType()}.ShowProbeSettings", true);
		m_SortingOrderProperty = this.serializedObject.FindProperty("m_SortingOrder");
		m_SortingLayerIdProperty = this.serializedObject.FindProperty("m_SortingLayerID");
	}
	
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		// Sorting Layer Settings
		this.m_ShowSortingLayerSettings.value = EditorGUILayout.BeginFoldoutHeaderGroup(this.m_ShowSortingLayerSettings.value, SortingLayersGUI.Styles.sortingLayerSettings);
		if (this.m_ShowSortingLayerSettings.value) {
			++EditorGUI.indentLevel;
			SortingLayerEditorUtility.RenderSortingLayerFields(m_SortingOrderProperty, m_SortingLayerIdProperty);
			--EditorGUI.indentLevel;
		}
		EditorGUILayout.EndFoldoutHeaderGroup();
		// Apply changes
		this.serializedObject.ApplyModifiedProperties();
	}
}