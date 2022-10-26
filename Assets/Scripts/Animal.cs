using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public float speed = 10.0f;
    public int attack = 10;

    // ENCAPSULATION
    public int health { get; protected set; }
    // ENCAPSULATION
    public int shield { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        shield = 100;
    }

    // ABSTRACTION
    protected virtual void Move()
    {
        transform.Rotate(transform.up, speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void TakeDamage(int damage)
    {
        shield -= damage;
        if (shield < 0)
        {
            health += shield;
            shield = 0;
        }
        if (health <= 0)
        {
            Die();
        }
        Debug.Log(gameObject.name + ": Shield: " + shield + " Health: " + health);
    }
    protected abstract void Die();
    private void OnCollisionEnter(Collision collision)
    {
        Animal other = collision.gameObject.GetComponent<Animal>();
        if (other)
        {
            other.TakeDamage(attack);
        }
    }
}
