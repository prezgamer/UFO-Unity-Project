using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    //Vector3 mousePos;
    //Vector3 currentRotation;

    public Transform ufo;
    Vector3 ufoTurret;

    [Header("Angle Variables")]
    public float rotationSpeed;
    public float maxZ, minZ;
    public float angleOffset;

    [Header("Projectile Variables")]
    public Transform bulletSpawn;
    public GameObject projectile;
    public GameObject beam;
    public int beamPower;
    public Slider beamSlider;
    float beamRechargeTime;
    bool beamIsEmpty = false;
    public float firerate;

    UFOController theUfo;

    //BeamCharge theBC;

    // Start is called before the first frame update
    void Start()
    {
        //mousePos = Input.mousePosition;
        //currentRotation = transform.rotation;
        ufoTurret = transform.position;
        beamPower = 100;
        beamSlider.value = beamPower;

        beam.SetActive(false);

        //theBC = FindObjectOfType<BeamCharge>();
        theUfo = FindObjectOfType<UFOController>();

        transform.position = ufo.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ufo.position;
        //ufoTurret.x = ufo.position.x - 2;

       // Debug.Log("Beam is at " + beamPower);
        beamSlider.value = beamPower;

        if (theUfo.hasFinished == true)
        {
            if (beamIsEmpty == false)
            {
                if (Input.GetMouseButton(1) && beamPower > 0)
                {
                    //theBC.gameObject.SetActive(true); //set the beam charge to be active
                    beam.SetActive(true);
                    beamPower -= 1;
                } /*else if (Input.GetMouseButtonUp(1))
            {
                theBC.FinishPower();
            }*/
                else
                {
                    beam.SetActive(false);
                    beamPower += 1;
                }
            }
            else if (beamIsEmpty == true)
            {
                //theBC.FinishPower();
                beam.SetActive(false);
                beamPower += 1;
            }

            if (beamPower >= 100)
            {
                beamPower = 100;
                beamIsEmpty = false;
            }
            else if (beamPower == 0)
            {
                beamIsEmpty = true;
            }

            if (firerate <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(projectile, bulletSpawn.position, transform.rotation); //spawn projectile at bulletSpawn Location and also set the rotation to be the same as the current rotation 
                                                                                       //of the gun
                    firerate = 0.5f;
                }
            }
            else if (firerate > 0) //else if firerate is more than 0
            {
                firerate -= Time.deltaTime;
            }
        }

        //this calculate the turret angle
        //Vector3 directOfAngle = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //check the direction of the angle from Mouse pos to the turret pos
        //float angleOfTurret = Mathf.Atan2(directOfAngle.y, directOfAngle.x) * Mathf.Rad2Deg; //calculate by using phyhogrosis thorem and then times rad to degrees

        CalculateAngle();

        //transform.rotation = Quaternion.Euler(0, 0, angleOfTurret + angleOffset);

        //Mathf.Clamp(angleOfTurret, minZ, maxZ); //stops the angle from rotation 360 degrees
        /*if (transform.rotation.z > 60)
        {
            Quaternion.Euler(0, 0, 60);
        }*/

        //this rotates the turret
        // Quaternion angleAxisZ = Quaternion.AngleAxis(angleOfTurret, transform.forward); 
        //transform.rotation = Quaternion.Slerp(transform.rotation, angleAxisZ, Time.deltaTime * rotationSpeed);

        //once firerare is below 0 or 0
        /*if (firerate <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, bulletSpawn.position, transform.rotation); //spawn projectile at bulletSpawn Location and also set the rotation to be the same as the current rotation 
                //of the gun
                firerate = 0.5f;
            }
        } else if (firerate > 0) //else if firerate is more than 0
        {
            firerate -= Time.deltaTime;
        }*/

        //Debug.Log("Angle between turret and mouse is " + angleOfTurret);
    }

    void CalculateAngle()
    {
        Vector3 directOfAngle = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //check the direction of the angle from Mouse pos to the turret pos
        float angleOfTurret = Mathf.Atan2(directOfAngle.y, directOfAngle.x) * Mathf.Rad2Deg; //calculate by using phyhogrosis thorem and then times rad to degrees
        transform.rotation = Quaternion.Euler(0, 0, angleOfTurret + angleOffset);
    }
}
