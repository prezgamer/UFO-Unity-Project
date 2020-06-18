using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETRay : MonoBehaviour
{
    UFOController theUFO;
    public int damage;

    private void Start()
    {
        theUFO = FindObjectOfType<UFOController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            theUFO.TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            theUFO.TakeDamage(damage);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UFO")
        {
            theUFO.TakeDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UFO")
        {
            theUFO.TakeDamage();
        }
    }*/


}
