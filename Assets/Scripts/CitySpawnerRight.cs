using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawnerRight : MonoBehaviour
{
    Transform ufo;
    public Transform rightLimit;
    public Transform rightCitySpawn;

    public bool hasSpawned;
    public GameObject cities;

    // Start is called before the first frame update
    void Start()
    {
        ufo = GameObject.Find("UFO").transform;

        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ufo.position.x >= rightLimit.position.x && hasSpawned == false)
        {
            Instantiate(cities, rightCitySpawn.position, Quaternion.identity);
            //Debug.Log("Current Right Position: " + rightUfoTf.position.x + " is greater than " + rightLimit.position.x + " ,therefore, create right city");
            hasSpawned = true;
        }
    }
}
