using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    // ENCAPSULATION

    private bool direction;
    private Rigidbody rbMech;
    private GameObject fox;

    // Start is called before the first frame update
    void Start()
    {
        rbMech = GetComponent<Rigidbody>();
        fox = GameObject.Find("Fox");
        health = 50;
        shield = 150;
    }

    // The rabbit runs away
    // POLYMORPHISM
    protected override void Move()
    {
        Vector3 lookDirection = (fox.transform.position - transform.position).normalized;
        rbMech.AddForce(lookDirection * speed * -1);
    }

    // POLYMORPHISM
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
