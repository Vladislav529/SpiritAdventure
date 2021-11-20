using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingObject : InteractableObject
{
    [Header("Set in Inspector")]
    // public GameObject thingWeHold;
    public GameObject hand;


    private bool isPickedUp = false;

    Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Interaction()
    {
        if (!isPickedUp)
        {
            rigidbody.isKinematic = true;
            this.transform.SetParent(hand.transform);
            this.transform.position = hand.transform.position;
            isPickedUp = true;
        }
        else
        {
            rigidbody.isKinematic = false;
            this.transform.SetParent(null);
            isPickedUp = false;
        }
    }

    public Vector3 position => this.transform.position;
}