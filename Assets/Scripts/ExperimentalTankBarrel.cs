using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalTankBarrel : MonoBehaviour
{
    Transform ufoPos;
    public Transform barrelPos;
    public float offset;

    public GameObject tankRay;

    // Start is called before the first frame update
    void Start()
    {
        ufoPos = GameObject.Find("UFO").transform; //find UFO Pos when tank spawns
        tankRay.SetActive(false);
    }

    public void CalculateFiring()
    {
        bool hasFired = false;
        Vector3 directionToFire = ufoPos.position - transform.position;
        float angleOfBarrel = Mathf.Atan2(directionToFire.y, directionToFire.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleOfBarrel + offset);

        if (hasFired == false)
        {
            tankRay.SetActive(true);
            hasFired = true;
        }

        Debug.Log("hasFired is now " + hasFired);

        if (hasFired == true)
        {
            tankRay.SetActive(false);
        }

        Debug.Log("hasFired is now(True) " + hasFired);

        //transform.eulerAngles = Vector2.right * angleOfBarrel;

        /*if (hasFired == false)
        {
            if (hasFired == false)
            {
                //Instantiate(tankProjectile, barrelPos.position, transform.rotation);
                tankRay.SetActive(true);
                hasFired = true;
            } else
            {
                tankRay.SetActive(false);
            }
        }*/
    }

    public IEnumerator StartFiring()
    {
        bool hasFired = false;

        while(hasFired == false)
        {
            Vector3 directionToFire = ufoPos.position - transform.position;
            float angleOfBarrel = Mathf.Atan2(directionToFire.y, directionToFire.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angleOfBarrel + offset);

            yield return new WaitForSeconds(0.1f);

            tankRay.SetActive(true);

            hasFired = true;

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);

        tankRay.SetActive(false);
        hasFired = false;
    }
}
