using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionDialog : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject character;
    public GameObject dialog;
    public GameObject dialogAfterQuest;
    public GameObject powerUp1;
    public GameObject powerUp2;
    public float dialogDistance = 5f;


    private void Awake()
    {
        dialog.SetActive(false);
    }
    private void Update()
    {
        if (powerUp1.GetComponent<blockPowerUp>().powUp == true && powerUp2.GetComponent<blockPowerUp>().powUp == true)
        {
            dialog.SetActive(false);
            if (Vector3.Distance(this.transform.position, character.transform.position) < dialogDistance)
            {
                dialogAfterQuest.SetActive(true);
            }
            else
                dialogAfterQuest.SetActive(false);
        }
        else
        {
            dialogAfterQuest.SetActive(false);
            if (Vector3.Distance(this.transform.position, character.transform.position) < dialogDistance)
            {
                dialog.SetActive(true);
            }
            else
                dialog.SetActive(false);
        }
    }
}
