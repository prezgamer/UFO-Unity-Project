using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJetRight : MonoBehaviour
{
    public float jetSpeed;

    public GameObject projectile;
    public Transform projectileSpawn;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * jetSpeed);
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

        while (isFiring == true)
        {
            //Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            //isFiring = false;

            for (int p = 0; p < 5; p++)
            {
                yield return new WaitForSeconds(0.2f);
                Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            }

            isFiring = false;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
