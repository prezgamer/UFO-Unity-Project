using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    Transform ufoPos;
    public Transform barrelPos;
    public float offset;

    public GameObject tankProjectile;

    // Start is called before the first frame update
    void Start()
    {
        ufoPos = GameObject.Find("UFO").transform; //find UFO Pos when tank spawns
    }

    public void CalculateFiring()
    {
        bool hasFired = false;
        Vector3 directionToFire = ufoPos.position - transform.position;
        float angleOfBarrel = Mathf.Atan2(directionToFire.y, directionToFire.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0, 0, angleOfBarrel + offset);

        //transform.eulerAngles = Vector2.right * angleOfBarrel;

        if (hasFired == false)
        {
            Instantiate(tankProjectile, barrelPos.position, transform.rotation);
            hasFired = true;
        }

        /*bool fireReady = false;

        if (angleOfBarrel < -25f || angleOfBarrel > 0f)
        {
            fireReady = false;
        } else if (angleOfBarrel > -25f || angleOfBarrel < 0f)
        {
            fireReady = true;
        }

        if (!fireReady)
        {
            if (ufoPos.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1); //face right
                tankRb.velocity = new Vector2(tankSpeed, tankRb.velocity.y); //move right
            }
        }*/

    }
}
