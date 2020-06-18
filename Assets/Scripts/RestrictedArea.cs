using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestrictedArea : MonoBehaviour
{
    public float timeBefSpawn;
    public Text restrictedAreaText;
    public GameObject warningText;

    //FighterJet theJet;

    public GameObject[] jet;
    public Transform[] jetSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //warningText = GameObject.Find("Main Canvas/Warning Text");
        //restrictedAreaText = gameObject.GetComponent<Text>();

        warningText.SetActive(false);
        restrictedAreaText.text = "You are in Restricted Area, Leave now or be shot down!!";
        //theJet = FindObjectOfType<FighterJet>();
    }

    // Update is called once per frame
    void Update()
    {
        restrictedAreaText.text = "You are in Restricted Area, Leave now or be shot down!!";

        if (timeBefSpawn <= 0)
        {
            warningText.SetActive(true);
            ChooseSpawnLocation();
        }
    }

    public void ChooseSpawnLocation()
    {
        int randomSpawn = Random.Range(0, 4);

        switch (randomSpawn)
        {
            case 0:
                Instantiate(jet[0], jetSpawnPos[0].position, Quaternion.identity);
                //theJet.movingRight = true;
                timeBefSpawn = 2f;
                break;

            case 1:
                Instantiate(jet[1], jetSpawnPos[1].position, Quaternion.identity);
                //theJet.movingLeft = true;
                timeBefSpawn = 2f;
                break;

            case 2:
                Instantiate(jet[0], jetSpawnPos[2].position, Quaternion.identity);
                timeBefSpawn = 2f;
                break;

            case 3:
                Instantiate(jet[1], jetSpawnPos[3].position, Quaternion.identity);
                timeBefSpawn = 2f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            timeBefSpawn -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            timeBefSpawn -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            warningText.SetActive(false);
            //timeBefSpawn -= Time.deltaTime;
        }
    }
}
