using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    Transform ufo;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        ufo = GameObject.Find("UFO").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = ufo.position - transform.position;

        float angleToUFO = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleToUFO + offset);
    }
}
