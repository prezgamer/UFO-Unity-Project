using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float destroyOverTime;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        DestroyOverTime();
    }

    public void DestroyOverTime()
    {
        destroyOverTime -= Time.deltaTime;

        if (destroyOverTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
