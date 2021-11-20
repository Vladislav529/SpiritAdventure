using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject PowerUp;

    [HideInInspector]
    private List<short> enteringObjects = new List<short>();
    private bool spawned = false;

    private void Awake()
    {
        PowerUp.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject enteringObject = collision.gameObject;
        HoldingObject enteringObjectProperties = enteringObject.GetComponent<HoldingObject>(); 

        if(enteringObject.layer == 7)
        {
            if (!enteringObjects.Contains(enteringObjectProperties.id))
            {
                enteringObjects.Add(enteringObjectProperties.id);
            }
        }
    }

    private void LateUpdate()
    {
        if(enteringObjects.Contains(0) && enteringObjects.Contains(1) && enteringObjects.Contains(2) && !spawned)
        {
            PowerUp.SetActive(true);
            Vector3 position = new Vector3();
            position.x += 2;
            PowerUp.transform.position = position;
            spawned = true;
        }
    }
}
