using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedVehicle : MonoBehaviour
{
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, force);
    }

    void DestroyOverTime()
    {
        Destroy(this.gameObject);
    }
}
