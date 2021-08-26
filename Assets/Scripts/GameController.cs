using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //initializing variables
    public int health = 50;
    public int speed = 10;
    public int jumpIntensity = 7;
    public int timer = 10;
    public int level = 1;
    public bool CalledEnd = false;
    [SerializeField] private MyCharacterController charController;
    [SerializeField] private Text timerText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text levelText;
    [SerializeField] public Text updateField;
    [SerializeField] private Text advanceText;
    [SerializeField] public bool isPaused = false;

    //initializing variables
        private void Start()
    {

        //load information
        health = PlayerPrefs.GetInt("PlayerHealth", 50); //get current health if no health default is fifty
        speed = PlayerPrefs.GetInt("PlayerSpeed", 10); //get current speed if no speed default is ten
        level = PlayerPrefs.GetInt("PlayerLevel", 1); //get current level if no level default is one
        StartCoroutine("CountDown");//start the countdown
    }


    IEnumerator CountDown()
    {
        while(timer > 0)//while time is greater than 0
        {

            timerText.text = "Timer : " + timer; //update the timer variable in the UI
            healthText.text = "Health : " + health; //update the health variable in the UI
            levelText.text = "Level : " + level; //update the level variable in the UI
            advanceText.text = " "; //update the advance text in the UI
            yield return new WaitForSeconds(1); //wait for one second
            if(!CalledEnd && !isPaused && !charController.hasFallen){ //if the end game functino is not called and the screen isnt paused or the character hasn't fallen off the platform
                    timer--; //decrement time
            }
        }
        advanceText.text = "Advancing to the next Level..."; //show advancing text when the time is 0 or less than 0
        //GameObject.FindGameObjectWithTag("Player").GetComponent<MyCharacterController>().enabled = false; //pause the player when changing scenes
        yield return new WaitForSeconds(1); //wait for one second
        while(isPaused) //while the game is paused
            yield return null; //do nothing
        ChangeLevel();//change the level

    }

    private void ChangeLevel()
    {
        
        //save information
        PlayerPrefs.SetInt("PlayerHealth", health); //save player current health so it stays the same when changed 
        PlayerPrefs.SetInt("PlayerSpeed", speed+5); //save player current speed so it stays the same when changed
        PlayerPrefs.SetInt("PlayerLevel", level+1); //save player current level so it stays the same when changed (incremented by 1)

        Scene scene = SceneManager.GetActiveScene(); //get the current active scene

        // Check if the name of the current Active Scene is your first Scene.
        if (scene.name == "Level 0") //if the current scene is 0
        { 
            SceneManager.LoadScene("Level 1");//change to level 1
        }
        else if (scene.name == "Level 1") //if the current scene is 1
        {
            SceneManager.LoadScene("Level 2");//change to level 2
        }else{ //if the scene is 2 then 
            SceneManager.LoadScene("Level 0");//change to first scene level 0

        }
        //SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%3);
    }
    private void Update() 
    {
        if (health <= 0) //if health is 0 or lower
            GameOver(); //call gameover function
    }

    private void GameOver() 
    {
        CalledEnd = true; //set boolean true

        Debug.Log("GAME OVER!!"); //output to log
            
            
    }

    private void OnApplicationQuit(){ //before application is quit
        PlayerPrefs.DeleteKey("PlayerHealth"); //reset the health
        PlayerPrefs.DeleteKey("PlayerSpeed"); //reset the speed
        PlayerPrefs.DeleteKey("PlayerLevel"); //reset the level 

    }

}
