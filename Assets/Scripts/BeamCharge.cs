using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamCharge : MonoBehaviour
{
    /*public GameObject beam;
    public int beamPower;
    public Slider beamSlider;

    public Animator beamChargeAnim;
    Turret ufoTurret;

    // Start is called before the first frame update
    void Start()
    {
        beam.SetActive(false);
        this.gameObject.SetActive(false);
        beamChargeAnim = GetComponent<Animator>();
        ufoTurret = FindObjectOfType<Turret>();

        beamSlider.value = beamPower;
    }

    private void Update()
    {
        beamSlider.value = beamPower;
    }

    public void ChargeUpFire()
    {
        beam.SetActive(true);
        beamPower -= 1;
        beamChargeAnim.speed = 0;
    }

    public void StopChargingFire()
    {
        //beam.SetActive(false);
        //beamChargeAnim.speed = 0;
        this.gameObject.SetActive(false);
    }

    public void FinishPower()
    {
        /*beam.SetActive(false);
        beamPower += 1;
        beamChargeAnim.speed = 1;
        StartCoroutine(StartCharging());
    }

    IEnumerator StartCharging()
    {
        while (beamPower < 100)
        {
            beamPower += 1;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.1f);

        beamChargeAnim.speed = 1;
    }

    IEnumerator UsingBeam()
    {
        bool isUsingBeam = true;

        while (isUsingBeam == true)
        {
            beam.SetActive(true);
            beamPower -= 1;
            beamChargeAnim.speed = 0;

            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds
    }*/
}
