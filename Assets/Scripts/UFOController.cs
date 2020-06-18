using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOController : MonoBehaviour
{
    [Header("Limit Variables")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    [Header("Transform Variables")]
    //public Transform top, bottom, left, right;
    //public Transform bulletSpawn;

    public float flySpeed;
    public int health;
    public int damage;

    public bool hasFinished = false;
    public Transform ufoPos;
    public Transform movePos;

    int damageResist;
    //public GameObject projectile;

    public Slider healthSlider;
    Rigidbody2D rb;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 100;

        StartCoroutine(Gameover());
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        if (hasFinished == false)
        {
            Debug.Log("Player have not reach pos");
            transform.position = Vector2.MoveTowards(ufoPos.position, movePos.position, 50 * Time.deltaTime);
        }

        if (ufoPos.position == movePos.position)
        {
            Debug.Log("Player have reach pos");
            hasFinished = true;
        }

        if (hasFinished == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, flySpeed);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, -flySpeed);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-flySpeed, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(flySpeed, rb.velocity.y);
            }

            if (Input.GetKeyUp(KeyCode.A) ||
                Input.GetKeyUp(KeyCode.S) ||
                Input.GetKeyUp(KeyCode.D) ||
                Input.GetKeyUp(KeyCode.W) ||
                Input.GetKeyUp(KeyCode.UpArrow) ||
                Input.GetKeyUp(KeyCode.DownArrow) ||
                Input.GetKeyUp(KeyCode.LeftArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(0, 0);
            }

            /*if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, bulletSpawn.position, transform.rotation);
            }*/

            Mathf.Clamp(transform.position.x, xMin, xMax); //limit the transform.pos.x
            Mathf.Clamp(transform.position.y, yMin, yMax); //limit the transform.pos.y
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "JetAtk")
        {
            TakeDamage(damage);
            Destroy(other.gameObject);
        } 

        if (other.tag == "TankAtk")
        {
            TakeDamage(damage);
            Destroy(other.gameObject);
        }

        if (other.tag == "ETBeamAtk")
        {
            TakeDamage(damage);
            //Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int amtOfDamage)
    {
        health -= amtOfDamage;
        Debug.Log("Damage Taken " + amtOfDamage);
    }

    IEnumerator Gameover()
    {
        while (health > 0)
        {
            gameOverScreen.SetActive(false);

            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.2f);

        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        hasFinished = false;
    }
}
