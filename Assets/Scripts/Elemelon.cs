using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemelon : InteractableObject
{

    [Header("Set in Inspector")]
    public short elementId;
    public override void Interaction()
    {
        character.GetComponent<CharacterMovement>().elementId = elementId;
    }
}
// 0 - no element, 1 - air, 2 - green