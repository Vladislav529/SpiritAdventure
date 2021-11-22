using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingObject : InteractableObject
{
    [Header("Set in Inspector")]
    // public GameObject thingWeHold;
    public GameObject hand;
    public short id;
    public bool locked;


    private bool isPickedUp = false;

    Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Interaction()
    {
        if (!isPickedUp && !locked)
        {
            rigidbody.isKinematic = true;
            this.transform.SetParent(hand.transform);
            this.transform.position = hand.transform.position;
            isPickedUp = true;
            this.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            rigidbody.isKinematic = false;
            this.transform.SetParent(null);
            isPickedUp = false;
            if (!locked)
                this.GetComponent<ParticleSystem>().Play();
        }
    }

    public Vector3 position => this.transform.position;
}