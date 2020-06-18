using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliceMan : MonoBehaviour
{
    public float moveSpeed;
    public float timeBefMoving;

    public int health;
    public Slider healthSlider;

    Transform shootingArea;

    public int addScore;

    //public Transform[] detectionPos;
    //public Transform beamDetection;

    public enum movementType
    {
        moveRight, moveLeft
    }
    public movementType peopleMovement;

    public GameObject[] bodyParts;

    Rigidbody2D peopleRb;

    LevelManager lM;

    // Start is called before the first frame update
    void Start()
    {
        peopleRb = GetComponent<Rigidbody2D>();
        lM = FindObjectOfType<LevelManager>();

        healthSlider.value = health;

        //beamDetection = GameObject.Find("BeamReaction").transform;
        moveSpeed = 2f;

        //healthSlider.gameObject.SetActive(false);
        lM.currentNumOfPD += 1; //add 1 people to the current count of people

        ChangeMovementType(movementType.moveLeft);
    }

    private void Update()
    {
        healthSlider.value = health;

        /*if(beamDetection.position.x > detectionPos[0].position.x 
            && beamDetection.position.x > detectionPos[3].position.x 
            && beamDetection.position.y < detectionPos[2].position.y) {
            ChangeMovementType(movementType.runRight);
        } else if (beamDetection.position.x < detectionPos[1].position.x 
            && beamDetection.position.x < detectionPos[3].position.x 
            && beamDetection.position.y < detectionPos[2].position.y){
            Debug.Log("Beam is at " + beamDetection.position.y + ", Therefore, its less than " + detectionPos[2].position);
            ChangeMovementType(movementType.runLeft);
        }*/

        if (transform.position.y < -15)
        {
            Destroy(this.gameObject);
        }

        healthSlider.value = health;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (timeBefMoving > 0)
        {
            timeBefMoving -= Time.deltaTime;
        }

       // if
    }

    public void ChangeMovementType(movementType movementTP)
    {
        switch (movementTP)
        {
            case movementType.moveLeft:
                StartCoroutine("MoveLeft");
                break;

            case movementType.moveRight:
                StartCoroutine("MoveRight");
                break;

                /*case movementType.runLeft:
                    StartCoroutine("RunLeft");
                    break;

                case movementType.runRight:
                    StartCoroutine("RunRight");
                    break;*/
        }
    }

    public void ChooseRandomMovement()
    {
        float randomMovement = Random.Range(0, 2);

        if (randomMovement == 0)
        {
            ChangeMovementType(movementType.moveLeft);
            Debug.Log("Moving left");
        }
        else if (randomMovement == 1)
        {
            ChangeMovementType(movementType.moveRight);
            Debug.Log("Moving Right");
        }
        else if (randomMovement == 2)
        {
            Debug.Log("Do Nothing");
        }
    }

    public IEnumerator MoveLeft()
    {
        while (timeBefMoving > 0)
        {
            peopleRb.velocity = new Vector2(-moveSpeed, peopleRb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        timeBefMoving = 2f;

        ChooseRandomMovement();
    }

    public IEnumerator MoveRight()
    {
        while (timeBefMoving > 0)
        {
            peopleRb.velocity = new Vector2(moveSpeed, peopleRb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        timeBefMoving = 2f;

        ChooseRandomMovement();
    }

    /*public IEnumerator RunLeft()
    {
        while (timeBefMoving > 0)
        {
            peopleRb.velocity = new Vector2(-moveSpeed * 5, peopleRb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        timeBefMoving = 2f;

        ChooseRandomMovement();
    }

    public IEnumerator RunRight()
    {
        while (timeBefMoving > 0)
        {
            peopleRb.velocity = new Vector2(moveSpeed * 5, peopleRb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        timeBefMoving = 2f;

        ChooseRandomMovement();
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BeamAtk")
        {
            healthSlider.gameObject.SetActive(true);
            health -= 10;
        }

        if (other.tag == "Projectile")
        {
            healthSlider.gameObject.SetActive(true);
            health -= 30;
            Destroy(other.gameObject);
        }

        if (other.tag == "Wheel")
        {
            healthSlider.gameObject.SetActive(true);
            health -= 50;
            Destroy(other.gameObject);
        }

        if (other.tag == "PlanePart")
        {
            healthSlider.gameObject.SetActive(true);
            health -= 50;
        }

        if (other.tag == "Explosion")
        {
            //healthSlider.gameObject.SetActive(true);
            health -= 50;//lM.damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BeamAtk")
        {
            //healthSlider.gameObject.SetActive(true);
            health -= 10;
        }

        if (other.tag == "Explosion")
        {
            //healthSlider.gameObject.SetActive(true);
            health -= 50;//lM.damage);
        }
    }

    private void OnDestroy()
    {
        lM.scoreCount += addScore;
        lM.currentNumOfPD -= 1;

        Instantiate(bodyParts[0], transform.position, Quaternion.identity);
        Instantiate(bodyParts[1], transform.position, Quaternion.identity);
        Instantiate(bodyParts[2], transform.position, Quaternion.identity);
        Instantiate(bodyParts[3], transform.position, Quaternion.identity);
        Instantiate(bodyParts[4], transform.position, Quaternion.identity);
        Instantiate(bodyParts[5], transform.position, Quaternion.identity);
        Instantiate(bodyParts[6], transform.position, Quaternion.identity);

    }
}
