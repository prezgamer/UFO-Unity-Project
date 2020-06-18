using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ufo;
    Vector3 camera;

    public Transform areaToFollow;
    float yVelocity = 0.0f;
    float xVelocity = 0.0f;

    public float smoothSpeed;

    public float yMin;
    //public float yMin, yMax;
    public float xMin, xMax;
    //public Transform top, bottom, left, right;

    //Rigidbody2D camRb;

   // public float cameraMoveSpeed;
    //Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        //camRb = GetComponent<Rigidbody2D>();

        //transform.position = ufo.position - ; //set transform position to be same as ufo position by default
        //camPos = transform.position;

        camera = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera.y = 66;

        if (ufo.position.y < yMin)
        {
            transform.SetParent(null);
        }

        if (ufo.position.y > yMin)
        {
            //set parent to be ufo
            //smooth the camera movement by SmoothDamp Method, moving its Y and X positions to the areaToFollow positions Y and X respectively
            //set the timing to be 1 smoothtime per frame and follow it via its smoothSpeed
            transform.SetParent(ufo);
            float smoothY = Mathf.SmoothDamp(transform.position.y, areaToFollow.position.y, ref yVelocity, 1, smoothSpeed);
            float smoothX = Mathf.SmoothDamp(transform.position.x, areaToFollow.position.x, ref xVelocity, 1, smoothSpeed);
            transform.position = new Vector3(smoothX, smoothY, transform.position.z);
        }

        /*if (ufo.position.x < xMin || ufo.position.x > xMax)
        {
            transform.SetParent(null);
        }

        /*if (ufo.position.x > xMin || ufo.position.x < xMax)
        {
            //set parent to be ufo
            //smooth the camera movement by SmoothDamp Method, moving its Y and X positions to the areaToFollow positions Y and X respectively
            //set the timing to be 1 smoothtime per frame and follow it via its smoothSpeed
            transform.SetParent(ufo);
            float smoothY = Mathf.SmoothDamp(transform.position.y, areaToFollow.position.y, ref yVelocity, 1, smoothSpeed);
            float smoothX = Mathf.SmoothDamp(transform.position.x, areaToFollow.position.x, ref xVelocity, 1, smoothSpeed);
            transform.position = new Vector3(smoothX, smoothY, transform.position.z);
        }*/

        //transform.position = ufo.transform.position;

        //camera.x = ufo.position.x;

        /*if (ufo.position.y >= top.position.y)
        {
            Debug.Log("UFo position is more than camera position");
            camRb.velocity = new Vector2(camRb.velocity.x, cameraMoveSpeed) * Time.deltaTime;
        }

        if (ufo.position.y <= bottom.position.y)
        {
            camPos.y -= cameraMoveSpeed * Time.deltaTime;
        }

        if (ufo.position.x >= right.position.x)
        {
            camPos.x += cameraMoveSpeed * Time.deltaTime;
        }

        if (ufo.position.x <= left.position.x)
        {
            camPos.x -= cameraMoveSpeed * Time.deltaTime;
        }
        //transform.position = ufo.position;*/

        //Mathf.Clamp(transform.position.x, xMin, xMax);
        //Mathf.Clamp(transform.position.y, yMin, yMax);
    }
}
