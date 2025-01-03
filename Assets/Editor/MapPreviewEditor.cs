using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapPreview))]
public class MapPreviewEditor : Editor {

	public override void OnInspectorGUI() {
		MapPreview mapPreview = (MapPreview)target;

		if (DrawDefaultInspector ()) {
			if (mapPreview.enableautoUpdate) {
				mapPreview.RenderMapInEditor ();
			}
		}

		if (GUILayout.Button ("Generate")) {
			mapPreview.RenderMapInEditor ();
		}
	}
}
