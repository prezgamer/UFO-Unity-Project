using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetProjectileRight : MonoBehaviour
{
    public float pJSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * pJSpeed);
    }
}
