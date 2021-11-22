using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnPalka : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject palka;
    public GameObject character;
    public float spellDistance = 6f;

    
    private void Awake()
    { 
        palka.SetActive(false);
    }
    private void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < spellDistance
            && Input.GetKeyDown(KeyCode.E)
            && character.GetComponent<CharacterMovement>().elementId == 2)

        {
            palka.SetActive(true);
        }

    }
}
