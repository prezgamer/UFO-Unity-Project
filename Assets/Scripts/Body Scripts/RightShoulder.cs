using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightShoulder : MonoBehaviour
{
    //Rigidbody2D bodyRb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-force, force);
    }

    public void DestroyOverTime()
    {
        Destroy(this.gameObject);
    }
}
