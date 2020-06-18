using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : TankManager
{
    public override void Start()
    {
        base.Start();
    }

   /* public override void Update()
    {
        base.Update();
    }*/

    #region Old Code
    /*public enum MovementType
    {
        moveLeft, moveRight, stayIdle
    }
    [Header("Movement/Enum Variables")]
    public MovementType tankMovement;

    [Header("Score Variables")]
    public int addScore;

    [Header("Tank Variables")]
    public float tankSpeed;
    public float timeBefFiring;
    public float timeBefMoving;

    Transform ufoPos;
    Transform shootingRange;
    //public Transform barrel;
    public Transform barrelPos;
    public GameObject tankProjectile;

    public GameObject explosion;
    public GameObject tankDestroyed;

    [Header("Health Variables")]
    public int health;
    public Slider healthSlider;

    [Header("Components and script Variables")]
    Rigidbody2D tankRb;
    TankBarrel theTB;
    LevelManager lM;

    // Start is called before the first frame update
    void Start()
    {
        ufoPos = GameObject.Find("UFO").transform; //find UFO Pos when tank spawns
        theTB = FindObjectOfType<TankBarrel>();
        shootingRange = GameObject.Find("Shooting Range").transform;
        tankRb = GetComponent<Rigidbody2D>();
        lM = FindObjectOfType<LevelManager>();

        lM.currentNumOfTanks += 1; //add 1 tank to the current number of tanks
        healthSlider.gameObject.SetActive(false);

        ChangeMovementType(MovementType.stayIdle);

        //Invoke("Patrol", 5);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        if (transform.position.y < -15)
        {
            Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        /*if (ufoPos.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); //face right
            tankRb.velocity = new Vector2(tankSpeed, tankRb.velocity.y); //move right
        }

        if (ufoPos.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1); //face left
            tankRb.velocity = new Vector2(-tankSpeed, tankRb.velocity.y); //move left
        }

        if (ufoPos.position.x < transform.position.x + 2)
        {
            transform.localScale = new Vector3(1, 1, 1); //face left
            tankRb.velocity = new Vector2(tankRb.velocity.x, tankRb.velocity.y); //move left
        }

        if (ufoPos.position.x > transform.position.x - 2)
        {
            transform.localScale = new Vector3(-1, 1, 1); //face right
            tankRb.velocity = new Vector2(tankRb.velocity.x, tankRb.velocity.y); //move left
        }*/

    /* Mathf.Clamp(transform.position.x, -70, 70);

     if (ufoPos.position.y < shootingRange.position.y)
     {
         if (ufoPos.position.x < transform.position.x + 10 || ufoPos.position.x > transform.position.x - 10)
         {
             //StopAllCoroutines();

             if (timeBefFiring <= 0)
             {
                 theTB.CalculateFiring();
                 timeBefFiring = 2f;
             }
             else if (timeBefFiring > 0)
             {
                 timeBefFiring -= Time.deltaTime;
             }

             if (ufoPos.position.x > transform.position.x + 2)
             {
                 transform.localScale = new Vector3(-1, 1, 1); //face right
                 tankRb.velocity = new Vector2(tankSpeed, tankRb.velocity.y); //move right
             }

             if (ufoPos.position.x < transform.position.x)
             {
                 transform.localScale = new Vector3(1, 1, 1); //face left
                 tankRb.velocity = new Vector2(-tankSpeed, tankRb.velocity.y); //move left
             }
         }

         /*if (ufoPos.position.x < transform.position.x + 2)
         {
             transform.localScale = new Vector3(1, 1, 1); //face left
             tankRb.velocity = new Vector2(tankRb.velocity.x, tankRb.velocity.y); //move left
         }

         if (ufoPos.position.x > transform.position.x - 2)
         {
             transform.localScale = new Vector3(-1, 1, 1); //face right
             tankRb.velocity = new Vector2(tankRb.velocity.x, tankRb.velocity.y); //move left
         }*/
    /*  } else if (ufoPos.position.y > shootingRange.position.y)
      {
          //ChangeMovementType(MovementType.stayIdle);

          if (timeBefMoving > 0)
          {
              timeBefMoving -= Time.deltaTime;
          }
          //float timeBefChange = 5f;

          /*if (timeBefMoving <= 0)
          {
              //Patrol();
              //timeBefMoving = 5f;
              //timeBefChange = 5f;
              //Debug.Log("patrolling now");
          } else if (timeBefMoving > 0)
          {
              timeBefMoving -= Time.deltaTime;
          }*/
    // }
    //}

    /* public void Patrol()
     {
         //float timeBefChange = 5f;

         float randomMovement = Random.Range(0, 2);

         if (randomMovement == 0)
         {
             ChangeMovementType(MovementType.moveLeft);
             Debug.Log("Moving Left");
         } else if (randomMovement == 1)
         {
             ChangeMovementType(MovementType.moveRight);
             Debug.Log("Moving Right");
         } else if (randomMovement == 2)
         {
             ChangeMovementType(MovementType.stayIdle);
             Debug.Log("Staying Idle");
         }
         //ChangeMovementType(MovementType.moveLeft);
     }

     public void ChangeMovementType(MovementType tankMovement)
     {
         switch (tankMovement)
         {
             case MovementType.moveLeft:
                 //Debug.Log("Move Left");
                 //tankRb.velocity = new Vector2(-tankSpeed, tankRb.velocity.y);
                 //transform.localScale = new Vector3(1, 1, 1);
                 StartCoroutine("MovingLeft");
                 break;

             case MovementType.moveRight:
                 //Debug.Log("Move Left");
                 //tankRb.velocity = new Vector2(tankSpeed, tankRb.velocity.y);
                 //transform.localScale = new Vector3(-1, 1, 1);
                 StartCoroutine("MovingRight");
                 break;

             case MovementType.stayIdle:
                 //Debug.Log("Move Left");
                 //tankRb.velocity = new Vector2(0, 0);
                 //transform.localScale = new Vector3(1, 1, 1);
                 StartCoroutine("StayIdle");
                 break;
         }
     }

     IEnumerator MovingLeft()
     {
         //bool isMoving = true;
         while(timeBefMoving > 0)
         {
             tankRb.velocity = new Vector2(-tankSpeed, tankRb.velocity.y);
             transform.localScale = new Vector3(1, 1, 1);

             yield return new WaitForSeconds(0.5f);
         }

         yield return new WaitForSeconds(0.5f);
         timeBefMoving = 2.5f;

         Patrol();
     }

     IEnumerator MovingRight()
     {
         while (timeBefMoving > 0)
         {
             tankRb.velocity = new Vector2(tankSpeed, tankRb.velocity.y);
             transform.localScale = new Vector3(-1, 1, 1);

             yield return new WaitForSeconds(0.5f);
         }

         yield return new WaitForSeconds(0.5f);
         timeBefMoving = 2.5f;

         Patrol();
     }

     IEnumerator StayIdle()
     {
         while (timeBefMoving > 0)
         {
             tankRb.velocity = new Vector2(0, 0);
             //transform.localScale = new Vector3(-1, 1, 1);

             yield return new WaitForSeconds(0.5f);
         }

         yield return new WaitForSeconds(0.5f);
         timeBefMoving = 2.5f;

         Patrol();
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.tag == "BeamAtk")
         {
             healthSlider.gameObject.SetActive(true);
             TakeDamage(lM.damage);
         }

         if (other.tag == "Projectile")
         {
             healthSlider.gameObject.SetActive(true);
             TakeDamage(lM.damage);
             Destroy(other.gameObject);
         }

         if (other.tag == "Explosion")
         {
             healthSlider.gameObject.SetActive(true);
             TakeDamage(10);//lM.damage);
         }

         if (other.tag == "PlanePart")
         {
             TakeDamage(90);
         }
     }

     private void OnTriggerStay2D(Collider2D other)
     {
         if (other.tag == "BeamAtk")
         {
             healthSlider.gameObject.SetActive(true);
             TakeDamage(lM.damage);
         }

         if (other.tag == "Projectile")
         {
             healthSlider.gameObject.SetActive(true);
             TakeDamage(lM.damage);
             Destroy(other.gameObject);
         }

         if (other.tag == "Explosion")
         {
             healthSlider.gameObject.SetActive(true);
             TakeDamage(10);//lM.damage);
         }
     }

     private void OnDestroy()
     {
         lM.scoreCount += addScore;
         lM.currentNumOfTanks -= 1;

         Instantiate(explosion, transform.position, Quaternion.identity);
         Instantiate(tankDestroyed, transform.position, Quaternion.identity);
     }

     public void TakeDamage(int damage)
     {
         health -= damage;
     }

     /*public void CalculateFiring()
     {
         bool hasFired = false;
         Vector3 directionToFire = ufoPos.position - barrel.position;
         float angleOfBarrel = Mathf.Atan2(directionToFire.y, directionToFire.x) * Mathf.Rad2Deg;

         if (hasFired == false)
         {
             Instantiate(tankProjectile, barrelPos.position, transform.rotation);
             hasFired = true;
         }

         /*bool fireReady = false;

         if (angleOfBarrel < -25f || angleOfBarrel > 0f)
         {
             fireReady = false;
         } else if (angleOfBarrel > -25f || angleOfBarrel < 0f)
         {
             fireReady = true;
         }

         if (!fireReady)
         {
             if (ufoPos.position.x > transform.position.x)
             {
                 transform.localScale = new Vector3(1, 1, 1); //face right
                 tankRb.velocity = new Vector2(tankSpeed, tankRb.velocity.y); //move right
             }
         }

     }*/
    #endregion
}
