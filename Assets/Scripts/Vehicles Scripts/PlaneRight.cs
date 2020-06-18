using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneRight : MonoBehaviour
{
    public float flySpeed;

    public int health;
    public Slider healthSlider;

    float timeBefShowing;

    public Transform areaToRespawn;

    public GameObject planeDestroyedRight;

    private void Awake()
    {
        FindObjectOfType<LevelManager>().currentNumOfPlanes += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100; //by default, health is 100
        healthSlider.value = health;
        healthSlider.gameObject.SetActive(false);

        timeBefShowing = 1f;

        areaToRespawn = GameObject.Find("SpawnPosC(Left)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        GetComponent<Rigidbody2D>().velocity = new Vector2(-flySpeed, GetComponent<Rigidbody2D>().velocity.y); //move right

        if (transform.position.x > 440)
        {
            transform.position = areaToRespawn.position;
            //Destroy(this.gameObject);
        }

        timeBefShowing -= Time.deltaTime;

        if (timeBefShowing <= 0)
        {
            healthSlider.gameObject.SetActive(false);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BeamAtk")
        {
            timeBefShowing = 0.5f;
            health -= 10;
        }

        if (other.tag == "Projectile")
        {
            timeBefShowing = 0.5f;
            health -= 10;
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().currentNumOfPlanes -= 1;
        Instantiate(planeDestroyedRight, transform.position, Quaternion.identity);
    }
}
