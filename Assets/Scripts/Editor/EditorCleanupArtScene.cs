using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorCleanupArtScene : MonoBehaviour
{
	[MenuItem("Tools/CleanupArtScene")]
	private static void CleanupArtScene()
	{
		foreach (var gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
		{
			var childrenComponents = gameObject.GetComponentsInChildren<Component>();
			foreach (var c in childrenComponents)
			{
				if (c is Transform || c is SpriteRenderer)
					continue;
				var cParent = c.gameObject;
				DestroyImmediate(c);
				//if (c.gameObject.GetComponentsInChildren<Component>().Length == 1)
				//	Destroy(cParent);
			}
		}
	}
}
