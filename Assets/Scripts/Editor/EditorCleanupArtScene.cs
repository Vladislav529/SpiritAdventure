using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorCleanupArtScene : MonoBehaviour
{
	private const string ART_SCENE = "Art";
	private const string DESIGN_SCENE = "Game";
	[MenuItem("Tools/CleanupArtScene")]
	private static void CleanupArtScene()
	{
		if (SceneManager.GetActiveScene().name != ART_SCENE)
			return;

		foreach (var gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			var childrenComponents = gameObject.GetComponentsInChildren<Component>();
			foreach (var c in childrenComponents)
			{
				if (c is Transform || c is SpriteRenderer || c is Camera)
					continue;
				var cParent = c.gameObject;
				DestroyImmediate(c);
				//if (c.gameObject.GetComponentsInChildren<Component>().Length == 1)
				//	Destroy(cParent);
			}
		}
	}

	[MenuItem("Tools/Hide colliders on design scene")]
	private static void HideCollidersOnDesignScene()
	{
		if (SceneManager.GetActiveScene().name != DESIGN_SCENE)
			return;

		ChangeDesignSceneCollidersVisibility(false);
	}
	
	private static void ChangeDesignSceneCollidersVisibility(bool visible)
	{
		foreach (var gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			var childrenComponents = gameObject.GetComponentsInChildren<Component>();
			foreach (var c in childrenComponents)
			{
				if (c.gameObject.layer == LayerMask.NameToLayer("ground") && c is SpriteRenderer)
					(c as SpriteRenderer).enabled = visible;
			}
		}

		EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
	}
	
	[MenuItem("Tools/Show colliders on design scene")]
	private static void ShowCollidersOnDesignScene()
	{
		if (SceneManager.GetActiveScene().name != DESIGN_SCENE)
			return;
		ChangeDesignSceneCollidersVisibility(true);
	}
}
