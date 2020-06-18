using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWheel : MonoBehaviour
{
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-force, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void DestroyOverTime()
    {
        Destroy(this.gameObject);
    }
}
