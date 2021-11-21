using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public WindowManager windowManager;
    [Header("Set in Inspector")]
    public GameObject character;
    public GameObject camera;

    private void LateUpdate()
    {
        Vector3 characterPos = character.transform.position;    

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            foreach (var go in scene.GetRootGameObjects())
            {
                foreach (var c in go.GetComponentsInChildren<Camera>())
                    c.transform.position = new Vector3(characterPos.x, characterPos.y + 2, c.transform.position.z);
            }
        }
        //      camera.transform.position = new Vector3(characterPos.x, characterPos.y + 2, camera.transform.position.z);
    }
}