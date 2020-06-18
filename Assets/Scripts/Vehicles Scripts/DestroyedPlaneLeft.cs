using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPlaneLeft : MonoBehaviour
{
    public float glideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-glideSpeed, glideSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            GetComponent<Animator>().SetTrigger("Despawn");
        }
    }

    public void DestroyOverTime()
    {
        Destroy(this.gameObject);
    }
}
