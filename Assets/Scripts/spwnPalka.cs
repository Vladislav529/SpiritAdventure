using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnPalka : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject palka;
    public GameObject character;
    public WindowManager windowManager;
    public float spellDistance = 6f;
    public bool isHuntUse = false;
    
    public void Awake()
    { 
        palka.SetActive(false);
    }
    public void Update()
    {
        if (Vector3.Distance(character.transform.position, palka.transform.position) < spellDistance
            && character.GetComponent<CharacterMovement>().elementId == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                palka.SetActive(true);
                palka.GetComponent<SpriteRenderer>().enabled = true;
                windowManager.CloseWindow(window: windowManager.GetLastOpenedWindow());
            }
            else if (!isHuntUse)
            {
                windowManager.ShowWindow("HintUse");
                isHuntUse = true;
            }
        }
        else if (character.GetComponent<CharacterMovement>().elementId == 2)
        {
            windowManager.CloseWindow(window: windowManager.GetLastOpenedWindow());
            isHuntUse = false;
        }
    }
}
