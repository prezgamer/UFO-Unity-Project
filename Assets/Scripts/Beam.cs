using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    Transform ufoBarrel;

    // Start is called before the first frame update
    void Start()
    {
        ufoBarrel = GameObject.Find("UFO Turret(test)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = ufoBarrel.rotation; //set rotation to be the same as the ufo barrel rotation 
    }
}
