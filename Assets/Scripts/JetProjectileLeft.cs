using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetProjectileLeft : MonoBehaviour
{
    public float pJSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * -pJSpeed);
    }
}
