using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    // ENCAPSULATION
    [SerializeField]
    private GameObject explosion;

    private Rigidbody rbMech;
    private GameObject rabbit;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        shield = 100;
        rbMech = GetComponent<Rigidbody>();
        rabbit = GameObject.Find("Rabbit");
    }

    // The fox chases
    // POLYMORPHISM
    protected override void Move()
    {
        if (rabbit != null)
        {
            Vector3 lookDirection = (rabbit.transform.position - transform.position).normalized;
            rbMech.AddForce(lookDirection * speed);
        }
    }

    // POLYMORPHISM
    protected override void Die()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Destroy(gameObject);
    }

}
