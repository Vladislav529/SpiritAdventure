using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnPalka : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject palka;
    public GameObject character;
    public float spellDistance = 6f;

    
    public void Awake()
    { 
        palka.SetActive(false);
        print("Awake");
    }
    public void Update()
    {
        if (Vector3.Distance(character.transform.position, palka.transform.position) < spellDistance
            && Input.GetKeyDown(KeyCode.E)
            && character.GetComponent<CharacterMovement>().elementId == 2)

        {
            print("Yeah");
            palka.SetActive(true);
        }

    }
}
