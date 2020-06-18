using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJetLeft : MonoBehaviour
{
    public float jetSpeed;

    public GameObject projectile;
    public Transform projectileSpawn;
    //public bool movingLeft = false;
    //public bool movingRight = false;
    //Rigidbody2D jetRb;

    // Start is called before the first frame update
    void Start()
    {
        //jetRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool movingLeft = false;
        //bool movingRight = false;

        /*if (movingLeft)
        {
            transform.position = Vector2.left * jetSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        } else if (movingRight)
        {
            transform.position = Vector2.right * jetSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }*/

        transform.Translate(Vector2.right * jetSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "UFO")
        {
            StartCoroutine("FireProjectile");
        }
    }

    IEnumerator FireProjectile()
    {
        bool isFiring = true;

        while(isFiring == true)
        {
            //Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            //isFiring = false;

            for(int p = 0; p < 5; p++)
            {
                yield return new WaitForSeconds(0.2f);
                Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            }

            isFiring = false;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
