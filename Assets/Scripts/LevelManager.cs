using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Number of Cars")]
    public int maxCars;
    public int currentNumOfCars;

    [Header("Number of Policemen")]
    public int maxPD;
    public int currentNumOfPD;

    [Header("Number of normal Tanks")]
    public int maxTanks;
    public int currentNumOfTanks;

    [Header("Number of experimental Tanks")]
    public int maxETanks;
    public int currentNumofETanks;

    [Header("Number of people")]
    public int maxPeople;
    public int currentNumOfPeople;

    [Header("Number of Planes")]
    public int maxPlanes;
    public int currentNumOfPlanes;
    public float timeBefSpawningPlanes;

    [Header("Damage Variables")]
    public int damage;
    public int multipler;

    [Header("Score Variables")]
    public int scoreCount;
    public int highscoreCount;
    public Text highScoreText;
    public Text currentScoreText;
    public Text scoreText;
    public Image[] stars;

    [Header("City Number Variables")]
    public bool hasUsedNumber = false;
    public int cityNumber;

    public GameObject eTank;
    public GameObject tank;
    public GameObject people;
    public GameObject[] planes;
    public GameObject[] cars;

    public Transform[] areaSpawnPos;

    public float timeBefSpawning;

    // Start is called before the first frame update
    void Start()
    {
        //by default, all current numbers are 0
        currentNumOfTanks = 0;
        currentNumofETanks = 0;
        currentNumOfPeople = 0;
        currentNumOfCars = 0;
        currentNumOfPlanes = 0;

        cityNumber = 2;

        scoreCount = 0;
    }

    void start()
    {
        PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = "Score: " + scoreCount; //set the text for the current score
        scoreText.text = "Score: " + scoreCount; //set the text for the score
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore"); //set the text for the highscore
        PlayerPrefs.SetInt("Score", scoreCount); //save the current score

        //if the scorecount is more than what the previous score
        if (scoreCount > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", scoreCount);
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore"); //set the text for the highscore
        }

        if (scoreCount > 150)
        {
            if (currentNumOfPD <= maxPD)
            {
                if (timeBefSpawning <= 0)
                {

                }
                else if (timeBefSpawning > 0)
                {
                    timeBefSpawning -= Time.deltaTime;
                }
            }
        }

        if (currentNumOfPeople <= maxPeople)
        {
            if (timeBefSpawning <= 0)
            {
                RandomPeopleSpawn();
            } else if (timeBefSpawning > 0)
            {
                timeBefSpawning -= Time.deltaTime;
            }
        }

        if (currentNumOfPlanes <= maxPlanes)
        {
            if (timeBefSpawningPlanes <= 0)
            {
                RandomPlaneSpawn();
            }
            else if (timeBefSpawningPlanes > 0)
            {
                timeBefSpawning -= Time.deltaTime;
            }
        }

        if (currentNumOfCars <= maxCars)
        {
            if (timeBefSpawning <= 0)
            {
                RandomCarSpawn();
            } else if (timeBefSpawning > 0)
            {
                timeBefSpawning -= Time.deltaTime;
            }
        }

        if (scoreCount > 500)
        {
            stars[0].color = Color.yellow;

            if (currentNumOfTanks <= maxTanks)
            {
                if (timeBefSpawning <= 0)
                {
                    RandomTankSpawn();
                }
                else if (timeBefSpawning > 0)
                {
                    timeBefSpawning -= Time.deltaTime;
                }
            }
            else if (currentNumOfTanks > maxTanks)
            {
                Debug.Log("No more tanks allowed in scene");
            }
        }

        if (scoreCount > 1000)
        {
            stars[1].color = Color.yellow;

            if (currentNumofETanks <= maxETanks)
            {
                if (timeBefSpawning <= 0)
                {
                    RandomETankSpawn();
                }
                else if (timeBefSpawning > 0)
                {
                    timeBefSpawning -= Time.deltaTime;
                }
            }
            else if (currentNumofETanks > maxETanks)
            {
                Debug.Log("No more experimental tanks allowed in scene");
            }
        }

        /*if (hasUsedNumber)
        {
            cityNumber += 1;
            hasUsedNumber = false;
        }*/
    }

    public void RandomPlaneSpawn()
    {
        float randomSpawn = Random.Range(0, 1);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(planes[0], areaSpawnPos[7].position, Quaternion.identity); //left plane
                timeBefSpawningPlanes = 5f;
                break;

            case 1:
                Instantiate(planes[1], areaSpawnPos[8].position, Quaternion.identity); //right plan
                timeBefSpawningPlanes = 5f;
                break;
        }
    }

    public void RandomCarSpawn()
    {
        float randomSpawn = Random.Range(0, 12);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(cars[0], areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 1:
                Instantiate(cars[1], areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 2:
                Instantiate(cars[0], areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 3:
                Instantiate(cars[1], areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 4:
                Instantiate(cars[2], areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 5:
                Instantiate(cars[3], areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 6:
                Instantiate(cars[2], areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 7:
                Instantiate(cars[3], areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 8:
                Instantiate(cars[4], areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 9:
                Instantiate(cars[5], areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 10:
                Instantiate(cars[4], areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 11:
                Instantiate(cars[5], areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;
        }
    }

    public void RandomTankSpawn()
    {
        float randomSpawn = Random.Range(0, 7);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(tank, areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 1:
                Instantiate(tank, areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 2:
                Instantiate(tank, areaSpawnPos[2].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 3:
                Instantiate(tank, areaSpawnPos[3].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 4:
                Instantiate(tank, areaSpawnPos[4].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 5:
                Instantiate(tank, areaSpawnPos[5].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 6:
                Instantiate(tank, areaSpawnPos[6].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;
        }
    }

    public void RandomETankSpawn()
    {
        float randomSpawn = Random.Range(0, 7);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(eTank, areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 1:
                Instantiate(eTank, areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 2:
                Instantiate(eTank, areaSpawnPos[2].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 3:
                Instantiate(eTank, areaSpawnPos[3].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 4:
                Instantiate(eTank, areaSpawnPos[4].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 5:
                Instantiate(eTank, areaSpawnPos[5].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 6:
                Instantiate(eTank, areaSpawnPos[6].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;
        }
    }

    public void RandomPolicemenSpawn()
    {
        float randomSpawn = Random.Range(0, 7);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(people, areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 1:
                Instantiate(people, areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 2:
                Instantiate(people, areaSpawnPos[2].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 3:
                Instantiate(people, areaSpawnPos[3].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 4:
                Instantiate(people, areaSpawnPos[4].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 5:
                Instantiate(people, areaSpawnPos[5].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 6:
                Instantiate(people, areaSpawnPos[6].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;
        }
    }

    public void RandomPeopleSpawn()
    {
        float randomSpawn = Random.Range(0, 7);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(people, areaSpawnPos[0].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 1:
                Instantiate(people, areaSpawnPos[1].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 2:
                Instantiate(people, areaSpawnPos[2].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 3:
                Instantiate(people, areaSpawnPos[3].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 4:
                Instantiate(people, areaSpawnPos[4].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 5:
                Instantiate(people, areaSpawnPos[5].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;

            case 6:
                Instantiate(people, areaSpawnPos[6].position, Quaternion.identity);
                timeBefSpawning = 2f;
                break;
        }
    }

    public void DamageMultipler(int multiplier)
    {
        damage *= multiplier;
    }
}
