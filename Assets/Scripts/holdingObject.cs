using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingObject : MonoBehaviour
{
    [Header("Set in Inspector")]
    // public GameObject thingWeHold;
    public GameObject character;

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");

        print(xAxis);

        Vector3 position = transform.position;

        position.x = character.transform.position.x + xAxis;

        position.y = character.transform.position.y;

        transform.position = position;
    }

}
