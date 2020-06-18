using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    float timeBefMoving; //time before moving
    Rigidbody peopleRb; //rigidbody of the people
    float moveSpeed; //move speed

    public enum movementType
    {
        moveRight, moveLeft //movement types enums
    }
    public movementType peopleMovement; //movement type 

    public void ChangeMovementType(movementType movementTP)
    {
        switch (movementTP)
        {
            //get the AI to move left
            case movementType.moveLeft:
                StartCoroutine("MoveLeft");
                break;


            //get the AI to move right
            case movementType.moveRight:
                StartCoroutine("MoveRight");
                break;
        }
    }

    public void ChooseRandomMovement()
    {
        float randomMovement = Random.Range(0, 2);

        //if it is 0, move left
        if (randomMovement == 0)
        {
            ChangeMovementType(movementType.moveLeft);
            Debug.Log("Moving left");
        }
        else if (randomMovement == 1) //if it is 1, move right
        {
            ChangeMovementType(movementType.moveRight);
            Debug.Log("Moving Right");
        }
        else if (randomMovement == 2) //else if it is 2, just stay idle
        {
            Debug.Log("Do Nothing");
        }
    }

    public IEnumerator MoveLeft()
    {
        //when the time is still more than 0
        while (timeBefMoving > 0)
        {
            peopleRb.velocity = new Vector2(-moveSpeed, peopleRb.velocity.y); //move left
            transform.localScale = new Vector3(-1, 1, 1); //face left

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        timeBefMoving = 2f; //set time back to 2

        ChooseRandomMovement(); //choose a random movement
    }

    public IEnumerator MoveRight()
    {
        //when the time is still more than 0
        while (timeBefMoving > 0)
        {
            peopleRb.velocity = new Vector2(moveSpeed, peopleRb.velocity.y); //move right
            transform.localScale = new Vector3(1, 1, 1); //face right or default

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);
        timeBefMoving = 2f; //set time back to 2

        ChooseRandomMovement(); //choose a random movement
    }
}
