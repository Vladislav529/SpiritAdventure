using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionElement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject elemelon;
    public GameObject powerUp1;
    public GameObject powerUp2;

    [HideInInspector]
    private bool spawned = false;

    private void Awake()
    {
        elemelon.SetActive(false);
    }

    private void Update()
    {
        if (powerUp1.GetComponent<blockPowerUp>().powUp == true && powerUp2.GetComponent<blockPowerUp>().powUp == true && !spawned)
        {
            spawned = true;
            elemelon.SetActive(true);
            Vector3 position = new Vector3();
            position = this.transform.position;
            position.x -= 1;
            elemelon.transform.position = position;
        }
    }
}
