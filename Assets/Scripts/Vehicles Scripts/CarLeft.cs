using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLeft : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed;
    public int health;
    public int damage;

    public Transform areaToRespawn;

    public Slider healthSlider;

    public int addScore;
    public GameObject[] carBodies;
    public GameObject explosion;

    public Transform[] wheelSpawns;

    LevelManager lM;

    private void Awake()
    {
        FindObjectOfType<LevelManager>().currentNumOfCars += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<LevelManager>().currentNumOfCars += 1;

        rb = GetComponent<Rigidbody2D>();
        health = 50;

        healthSlider.value = health;

        areaToRespawn = GameObject.Find("AreaToRespawn(Left)").transform;

        //lM = FindObjectOfType<LevelManager>();
        //lM.currentNumOfCars += 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        //areaToRespawn = GameObject.Find("AreaToRespawn(Right)").transform;

        if (transform.position.x < -440)
        {
            transform.position = areaToRespawn.position;
            //Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        //move left and face left
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            health -= damage;
            Destroy(other.gameObject);
        }

        if (other.tag == "BeamAtk")
        {
            health -= damage;
        }

        if (other.tag == "Explosion")
        {
            //healthSlider.gameObject.SetActive(true);
            health -= 10;//lM.damage);
        }

        if (other.tag == "PlanePart")
        {
            health -= 50;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            health -= damage;
            Destroy(other.gameObject);
        }

        if (other.tag == "BeamAtk")
        {
            health -= damage;
        }

        if (other.tag == "Explosion")
        {
            //healthSlider.gameObject.SetActive(true);
            health -= 10;//lM.damage);
        }

        if (other.tag == "PlanePart")
        {
            health -= 50;
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().currentNumOfCars -= 1;
        FindObjectOfType<LevelManager>().scoreCount += addScore;
        Debug.Log("Gameobject is destroyed");

        Instantiate(carBodies[0], transform.position, Quaternion.identity);
        Instantiate(carBodies[1], wheelSpawns[0].position, Quaternion.identity);
        Instantiate(carBodies[2], wheelSpawns[1].position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
