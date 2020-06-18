using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarRight : MonoBehaviour
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

        areaToRespawn = GameObject.Find("AreaToRespawn(Right)").transform;
        healthSlider.value = health;

        //lM = FindObjectOfType<LevelManager>();
        //lM.currentNumOfCars += 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        //areaToRespawn = GameObject.Find("AreaToRespawn(Left)").transform;

        if (transform.position.x > 440)
        {
            transform.position = areaToRespawn.position;
        }

        if (health <= 0)
        {
            //FindObjectOfType<LevelManager>().scoreCount += addScore;
            //FindObjectOfType<LevelManager>().currentNumOfCars -= 1;
            Destroy(this.gameObject);

            //StartCoroutine("DestroyGameobj");
        }

        //move left and face left
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        transform.localScale = new Vector3(-1, 1, 1);
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

    /*IEnumerator DestroyGameobj()
    {
        bool hasGivenScore = false;

        if (hasGivenScore == false)
        {
            FindObjectOfType<LevelManager>().scoreCount += addScore;
            FindObjectOfType<LevelManager>().currentNumOfCars -= 1;
            hasGivenScore = true;
        }

        yield return new WaitForSeconds(0.1f);

        Destroy(this.gameObject);
    }*/

    private void OnDestroy()
    {
        //lM.currentNumOfCars -= 1;
        FindObjectOfType<LevelManager>().scoreCount += addScore;
        FindObjectOfType<LevelManager>().currentNumOfCars -= 1;
        //Debug.Log("Number of cars " + lM.currentNumOfCars);

        Instantiate(carBodies[0], transform.position, Quaternion.identity);
        Instantiate(carBodies[1], wheelSpawns[0].position, Quaternion.identity);
        Instantiate(carBodies[2], wheelSpawns[1].position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
