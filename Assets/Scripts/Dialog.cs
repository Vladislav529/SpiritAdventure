using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject character;
    public GameObject dialog;
    public float dialogDistance = 5f;


    private void Awake()
    {
        dialog.SetActive(false);
    }
    private void Update()
    {
        if (!this.GetComponent<Table>().spawned)
        {
            if (Vector3.Distance(this.transform.position, character.transform.position) < dialogDistance)
            {
                dialog.SetActive(true);
            }
            else
            {
                dialog.SetActive(false);
            }
        }
        else
        {
            dialog.SetActive(false);
        }
    }
}
