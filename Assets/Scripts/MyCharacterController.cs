using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    //Initialize Variables
    [SerializeField] private bool isGrounded = true;
    [SerializeField] public bool hasFallen = false;
    [SerializeField] private GameController gameController;

    //Initialize Variables
    private void Start()
    {
        if (!gameController) //if game controller is not assigned then assign gamecontroller 
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 1) * gameController.speed * Time.deltaTime; //move forward
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //if player is grounded
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gameController.jumpIntensity, ForceMode.Impulse); //allow jump
        // Allow player to drop down while in mid-air using down-arrow or S
        if(!isGrounded && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))) //if player wants to go down
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gameController.jumpIntensity * 2, ForceMode.Impulse); //allow down

        //Debug.Log("Update - " + Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")//if player has collided with platform
            isGrounded = true; //set grounded to true
        
        if(collision.gameObject.tag == "PlatDeath")//if player collides with platdeath
            hasFallen=true; //then they have fallen so set variable to true
        /*
        if (collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Obstacle Hit");
            gameController.health -= 10;
        }
        */
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform") //if player no longer collides with platform
            isGrounded = false;//set isgrounded to be false


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle") //if player collides with obstacle
        {
            Debug.Log("Obstacle Hit");
            gameController.health -= 10; //take off 10 health points
        }

        if (other.gameObject.tag == "Obstacle 2") //if player collides with obstacle 2
        {
            Debug.Log("Obstacle Damage");
            gameController.health = 0; //player dies
        }

        if (other.gameObject.tag == "Obstacle 3")//if player collides with obstacle 3
        {
            Debug.Log("Obstacle Damage");
            gameController.health = 0;//player dies
        }

        if (other.gameObject.tag == "Coin1") //if player collides with coin 1
        {
            Debug.Log("Removed Time");
            gameController.updateField.text = "Removed 1 Second from Time"; //update text to show what is happening bts
            gameController.timer -= 1; //remove one second from time
        }

        if (other.gameObject.tag == "Coin2")//if player collides with coin 2
        {
            Debug.Log("Added Health");
            gameController.updateField.text = "Added 10 health back"; //update text to show whats happening bts
            gameController.health += 10; //add 10 health to player
        }

        if (other.gameObject.tag == "Coin3")//if player collides with coin 3
        {
            Debug.Log("Added Speed");
                gameController.updateField.text = "Added Speed Boost of 1"; //update text tho show whats happening bts
                gameController.speed += 1; //add 1  to speed
            
        }

    }
}
