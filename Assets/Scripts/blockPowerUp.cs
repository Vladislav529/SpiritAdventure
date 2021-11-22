using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPowerUp : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject spritePower;
    public GameObject spritePowerless;
    public float powerUpDistance = 5;

    [HideInInspector]
    public bool powUp = false;

    private void Awake()
    {
        spritePower.SetActive(false);
        spritePowerless.SetActive(true);
    }

    private void Update()
    {
        if (powerUp1 != null)
        {
            if (Vector2.Distance(powerUp1.transform.position, transform.position) < powerUpDistance && !powUp)
            {
                powUp = true;
                Destroy(powerUp1);
                spritePower.SetActive(true);
                spritePowerless.SetActive(false);
            }
        }
        if (powerUp2 != null)
        {
            if (Vector2.Distance(powerUp2.transform.position, transform.position) < powerUpDistance && !powUp)
            {
                powUp = true;
                Destroy(powerUp2);
                spritePower.SetActive(true);
                spritePowerless.SetActive(false);
            }
        }
        //print(powUp);
    }
}
