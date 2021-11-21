using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnPalka : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject powerBox1;
    public GameObject powerBox2;
    public GameObject palka;


    private void Awake()
    {
        palka.SetActive(false);
    }
    private void Update()
    {
        if (powerBox1.GetComponent<blockPowerUp>().powUp == true && powerBox2.GetComponent<blockPowerUp>().powUp == true)
        {
            palka.SetActive(true);
        }
        print("1 " + powerBox1.GetComponent<blockPowerUp>().powUp);
        print("2 " + powerBox2.GetComponent<blockPowerUp>().powUp);

    }
}
