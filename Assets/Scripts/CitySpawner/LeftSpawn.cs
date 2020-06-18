using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSpawn : MonoBehaviour
{
    public Transform leftSpawnPos;

    Transform randomLoc;

    public GameObject city;

    //int cityNumber

    BoxCollider2D theBC2D;
    LevelManager lM;

    // Start is called before the first frame update
    void Start()
    {
        lM = FindObjectOfType<LevelManager>();

        randomLoc = GameObject.Find("RandomLoc").transform;
        //leftSpawnPos = 
        theBC2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            StartCoroutine("BuildCity");
            /*//bool hasBuilt = false;

            if (hasBuilt == false)
            { 
            /*Instantiate(city, leftSpawnPos.position, Quaternion.identity);
            hasBuilt = true;
            Destroy(theBC2D);
            }*/
        }
    }

    /*IEnumerator BuildCity()
    {
        bool hasBuild = false;

        while(hasBuild == false)
        {
            Instantiate(city, randomLoc.position, Quaternion.identity);
            city.name = "City " + lM.cityNumber;
            lM.hasUsedNumber = true;

            yield return new WaitForSeconds(0.5f);

            leftSpawnPos = GameObject.Find("City " + lM.cityNumber + "/LeftSpawnLoc").transform;
            city.transform.position = leftSpawnPos.position;
            //Instantiate(city, leftSpawnPos.position, Quaternion.identity);
            Destroy(theBC2D);
            hasBuild = true;
        }

        yield return new WaitForSeconds(0.2f);
    }*/
}
