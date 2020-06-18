using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    BoxCollider2D buildingCollider;
    Animator buildingAnim;

    //bool isHit;
    float timeBefDissapearing;
    int health;

    public int addScore;

    public Slider buildingHealthSlider;
    public Sprite buildingDestroyed;

    public GameObject explosion;
    public Transform explosionPos;

    LevelManager lM;

    // Start is called before the first frame update
    void Start()
    {
        buildingCollider = GetComponent<BoxCollider2D>();
        buildingAnim = GetComponent<Animator>();

        lM = FindObjectOfType<LevelManager>();

        buildingHealthSlider.value = health;
        //buildingHealthSlider.maxValue = health;
        buildingHealthSlider.gameObject.SetActive(false);

        //isHit = false;
        timeBefDissapearing = 0.5f;

        health = 100;
    }

    private void Update()
    {
        buildingHealthSlider.value = health;

        if (health <= 0)
        {
            StartCoroutine("Destroy");
            //buildingHealthSlider.gameObject.SetActive(false);
            //buildingAnim.SetTrigger("Destroy"); //play destroy anim
        }

        if (timeBefDissapearing > 0)
        {
            timeBefDissapearing -= Time.deltaTime;
        }
        else if (timeBefDissapearing <= 0)
        {
            buildingHealthSlider.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            //buildingAnim.SetTrigger("Destroy");
            health -= 10;
            buildingHealthSlider.gameObject.SetActive(true);
            timeBefDissapearing = 1f;
            Debug.Log("Building is Hit" + health);
            Destroy(other.gameObject); //destroy projectile
        }

        if (other.tag == "BeamAtk")
        {
            health -= 1;
            buildingHealthSlider.gameObject.SetActive(true);
            timeBefDissapearing = 1f;
            Debug.Log("Building is Beamed at" + health);
            //buildingAnim.SetTrigger("Destroy");
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BeamAtk")
        {
            health -= 1;
            buildingHealthSlider.gameObject.SetActive(true);
            timeBefDissapearing = 1f;
            Debug.Log("Building is Beamed at" + health);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BeamAtk")
        {
            health -= 1;
            buildingHealthSlider.gameObject.SetActive(true);
            timeBefDissapearing = 1f;
            Debug.Log("Building is Beamed at" + health);
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BeamAtk")
        {
            health -= 1;
            buildingHealthSlider.gameObject.SetActive(true);
            timeBefDissapearing = 1;
            Debug.Log("Building is Beamed at" + health);
            //buildingAnim.SetTrigger("Destroy");
        }
    }

    public void BuildingOnDestroy()
    {
        //lM.scoreCount += addScore;
        FindObjectOfType<LevelManager>().scoreCount += addScore;
        GetComponent<SpriteRenderer>().sprite = buildingDestroyed;

        Instantiate(explosion, explosionPos.position, Quaternion.identity); //might change in the future

        Destroy(buildingCollider);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);

        buildingHealthSlider.gameObject.SetActive(false);
        buildingAnim.SetTrigger("Destroy"); //play destroy anim
    }
}
