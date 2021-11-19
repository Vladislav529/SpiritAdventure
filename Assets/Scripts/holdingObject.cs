using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingObject : MonoBehaviour, IInteractableObject
{
    [Header("Set in Inspector")]
    // public GameObject thingWeHold;
    public CharacterMovement character;
    public GameObject hand;
    public float pickUpDistance = 10f;


    private bool isPickedUp = false;

    Rigidbody2D rigidbody;

    public void Interaction()
    {
        if (!isPickedUp)
        {
            this.transform.SetParent(hand.transform);
            isPickedUp = true;
        }
        else
        {
            this.transform.SetParent(null);
            isPickedUp = false;
        }
    }

    public Vector3 position => this.transform.position;

    private void Update()
    {

        if (Vector3.Distance(hand.transform.position, transform.position) <= pickUpDistance)
        {
            character.AddInteractableObject(this);
        }
        else
        {
            character.TryToRemoveInteractableObject(this);
        }
        
    }

}


public interface IInteractableObject
{
    void Interaction();

    Vector3 position { get; }
}