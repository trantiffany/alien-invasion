using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayScreens : MonoBehaviour
{

    //Initialize Variables    
    [SerializeField] private GameController gameManager;
    [SerializeField] private MyCharacterController playerController;

    public GameObject PauseScreen;
    public GameObject PauseButton;
    public GameObject EndScreen;
    public GameObject ReturnButton;
    public GameObject ChangeScreen;
    public bool GamePaused = false;
    public bool DisplayEnded = false;

    //Initialize Variables

    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false; //set boolean to be false
    }
 
    // Update is called once per frame
    void Update()
    {
        if (GamePaused) //if the game is paused
            Time.timeScale = 0; //set time scale to be 0 
        else
            Time.timeScale = 1; //set the time scale to be 1

        if(gameManager.CalledEnd){//if gameover function is called
            DisplayEnded = true; //set boolean to true
            DisplayEnd();//dispaly game over screen
        }

        if(playerController.hasFallen){ //if the player has fallen off map
            DisplayEnded = true; //set boolean to true
            DisplayEnd();//dispaly game over screen
        }

    }
     public void DisplayEnd(){
        GameObject.FindGameObjectWithTag("Player").GetComponent<MyCharacterController>().enabled = false; //pause the player
        EndScreen.SetActive(true);// set the end screen to show
        ReturnButton.SetActive(true); //set the return button to show
        
    }

    public void ReturnMain(){
        EndScreen.SetActive(false); //set the end screen to not show
        ReturnButton.SetActive(false); //set to not show
        PlayerPrefs.DeleteKey("PlayerHealth"); //reset health
        PlayerPrefs.DeleteKey("PlayerSpeed"); //reset speed
        PlayerPrefs.DeleteKey("PlayerLevel"); //reset level
        SceneManager.LoadScene("Title"); //load title main screen
        DisplayEnded = false; //set end screen boolean to be false
    }

    public void Reset(){
        EndScreen.SetActive(false); //set the end screen to not show
        ReturnButton.SetActive(false); //set to not show
        PlayerPrefs.DeleteKey("PlayerHealth"); //reset health
        PlayerPrefs.DeleteKey("PlayerSpeed"); //reset speed
        PlayerPrefs.DeleteKey("PlayerLevel"); //reset level
        SceneManager.LoadScene("Level 0"); //load title main screen
        DisplayEnded = false; //set end screen boolean to be false
    }
    public void PauseGame()
    {
        GamePaused = true; //set boolean to be true
        gameManager.isPaused = true; //set boolean to be true
        PauseScreen.SetActive(true); //set screen to show
        PauseButton.SetActive(false); //set button to show
    }
 
    public void ResumeGame()
    {
        GamePaused = false;//set boolean to be false
        gameManager.isPaused = false; //set boolean to be false
        PauseScreen.SetActive(false);//deactive showing screen
        PauseButton.SetActive(true);//show button
    }
}