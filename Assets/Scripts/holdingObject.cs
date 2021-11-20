using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingObject : InteractableObject
{
    [Header("Set in Inspector")]
    // public GameObject thingWeHold;
    public GameObject hand;


    private bool isPickedUp = false;

    Rigidbody2D rigidbody;

    public override void Interaction()
    {
        if (!isPickedUp)
        {
            this.transform.SetParent(hand.transform);
            this.transform.position = hand.transform.position;
            isPickedUp = true;
        }
        else
        {
            this.transform.SetParent(null);
            isPickedUp = false;
        }
    }

    public Vector3 position => this.transform.position;
}


public abstract class InteractableObject : MonoBehaviour
{
    public abstract void Interaction();

    [SerializeField] private CharacterMovement character;
    [SerializeField] private float pickUpDistance = 10f;

    public Vector3 position => transform.position;
    private bool _characterCanInteract;


    protected void Update()
    {
        
        var distanceWithCharacter = Vector3.Distance(character.transform.position, transform.position);
        if (distanceWithCharacter <= pickUpDistance && !_characterCanInteract)
        {
            _characterCanInteract = true;
            character.AddInteractableObject(this);
        }
        else
        {
            _characterCanInteract = false;
            character.TryToRemoveInteractableObject(this);
        }
    }
}