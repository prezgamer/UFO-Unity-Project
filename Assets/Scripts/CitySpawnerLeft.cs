using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawnerLeft : MonoBehaviour
{
    public Transform leftLimit;
    //public Transform rightLimit;

    public Transform leftCitySpawn;
    //public Transform rightCitySpawn;

    public GameObject cities;

    Transform ufo;

    //bool hasSpawned;
    bool hasSpawnedLeft;

    //public Transform leftUfoTf;
    //public Transform rightUfoTf;

    // Start is called before the first frame update
    void Start()
    {
        //leftUfoTf = GameObject.Find("UFO/Left TP").transform;
        //rightUfoTf = GameObject.Find("UFO/Right TP").transform;

        ufo = GameObject.Find("UFO").transform;

        //hasSpawned = false;
        hasSpawnedLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        //bool hasSpawned = false;
        //bool hasSpawnedLeft = false;

        if (ufo.position.x <= leftLimit.position.x && hasSpawnedLeft == false)
        {

            Instantiate(cities, leftCitySpawn.position, Quaternion.identity);
            //Debug.Log("Current Left Position: " + leftUfoTf.position.x + " is less than " + leftLimit.position.x + " ,therefore, create left city");
            hasSpawnedLeft = true;
        }

        /*if (ufo.position.x >= rightLimit.position.x && hasSpawned == false) //&& hasSpawned == false)
        {
            Instantiate(cities, rightCitySpawn.position, Quaternion.identity);
            //Debug.Log("Current Right Position: " + rightUfoTf.position.x + " is greater than " + rightLimit.position.x + " ,therefore, create right city");
            hasSpawned = true;
        }

        //SpawnLeftBuilding();
        //SpawnRightBuilding();

        /*void SpawnLeftBuilding()
        {
            if (ufo.position.x <= leftLimit.position.x) //&& hasSpawnedLeft == false)
            {
                if (hasSpawnedLeft == false)
                {
                    Instantiate(cities[0], leftCitySpawn.position, Quaternion.identity);
                    //Debug.Log("Current Left Position: " + leftUfoTf.position.x + " is less than " + leftLimit.position.x + " ,therefore, create left city");
                    hasSpawnedLeft = true;
                }
            }
        }

        void SpawnRightBuilding()
        {
            if (ufo.position.x >= rightLimit.position.x ) //&& hasSpawned == false)
            {
                if (hasSpawned == false)
                {
                    Instantiate(cities[0], rightCitySpawn.position, Quaternion.identity);
                    //Debug.Log("Current Right Position: " + rightUfoTf.position.x + " is greater than " + rightLimit.position.x + " ,therefore, create right city");
                    hasSpawned = true;
                }
                else
                {
                    Debug.Log("City have already spawned");
                }
            }
        }*/
    }
}
