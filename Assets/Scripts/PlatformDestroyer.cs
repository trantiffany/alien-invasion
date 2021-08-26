using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    
    //Initialize variables
    [SerializeField] private float distanceThreshold = 100;
    [SerializeField] private bool isStepped = false;
    private GameObject player;

    //Initialize variables
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find game object player 
    }

    private void Update()
    {
        if (isStepped && Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceThreshold) // && player.transform.position.z > gameObject.transform.position.z
            Destroy(gameObject); //destory platform if the player is far from platform and has already stepped on the platform ^
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player) //if the player collides with platform
            isStepped = true;//set the boolean to true
    }
}
