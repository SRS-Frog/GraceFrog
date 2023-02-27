using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeronAttributes : MonoBehaviour
{
    public Rigidbody2D rbHeron; // RigidBody2D for the Heron
    public bool heronDefeated = false;



    void Awake()
    {
        // find the Rigidbody2D component of the object that this script is attached to
        //rbHeron = GetComponent<Rigidbody2D>();
        //hitbox = transform.GetChild(1).gameObject;

    }
}
