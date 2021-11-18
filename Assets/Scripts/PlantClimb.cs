using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantClimb : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject character;
    public GameObject plant;
    public GameObject pressButtonDisclaimer;
    public float climbingSpeed = 0.1f;

    public static bool isClimbing = false;

    private bool isColliding = false;

    private void Awake()
    {
        plant.SetActive(false);
        pressButtonDisclaimer.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider);
        if(collider.gameObject == character) isColliding = true;
        pressButtonDisclaimer.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == character) isColliding = false;
        pressButtonDisclaimer.SetActive(false);
    }
   
    void createPlant()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            plant.SetActive(true);
        }
    }

   
    private void FixedUpdate()
    {
        createPlant();



        float yAxis = Input.GetAxis("Vertical");

        if (plant.activeInHierarchy == true && isColliding && Input.GetKeyDown(KeyCode.Space))
        {
            if(isClimbing == false)
            {
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
        }


        if (!isColliding) 
            isClimbing = false;

        
    }
}
