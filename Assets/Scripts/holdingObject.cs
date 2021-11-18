using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingObject : MonoBehaviour
{
    [Header("Set in Inspector")]
    // public GameObject thingWeHold;
    public GameObject character;
    public GameObject hand;

    private void Update()
    {
        transform.position = hand.transform.position;
    }

}
