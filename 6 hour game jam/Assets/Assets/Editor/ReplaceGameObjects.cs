using UnityEngine;
using UnityEditor;
using System.Collections;

public class ReplaceGameObjects : ScriptableWizard {
	public GameObject useGameObject;

	[MenuItem("Tools/Scene Tools/Replace GameObjects")]
	static void CreateWizard() {
		ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
	}

	void OnWizardCreate() {
		foreach (Transform t in Selection.transforms) {
			GameObject newObject = (GameObject)EditorUtility.InstantiatePrefab(useGameObject);
			Transform newT = newObject.transform;
			newT.position = t.position;
			newT.rotation = t.rotation;
			newT.localScale = t.localScale;
			newT.transform.parent = t.transform.parent;
		}
		foreach (GameObject go in Selection.gameObjects) {
			DestroyImmediate(go);
		}
	}
}