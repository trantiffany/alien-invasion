using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //Initialize Variables
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject fallenPlatformPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject coinPrefab1;
    [SerializeField] private GameObject coinPrefab2;
    [SerializeField] private GameObject coinPrefab3;
    [SerializeField] private float distanceThreshold = 50;
    private Vector3 nextPlatformPos = Vector3.zero;
    private Vector3 nextPlatformPosD;
    private GameObject player;

    //Initialize Variables
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(platformPrefab, nextPlatformPos, Quaternion.identity); // Gimbal Lock - Quaternions vs Euler Angles
        obstaclePrefab.transform.position = new Vector3(Random.Range(-2, 2), 1, Random.Range(-20, 20));//generate obstacles
     
        coinPrefab1.transform.position = new Vector3(Random.Range(-2, 2), 90, Random.Range(-20, 20));//generate obstacles
        coinPrefab2.transform.position = new Vector3(Random.Range(-2, 2), 90, Random.Range(-20, 20));//generate obstacles
        coinPrefab3.transform.position = new Vector3(Random.Range(-2, 2), 90, Random.Range(-20, 20));//generate obstacles

        nextPlatformPos += new Vector3(0, 0, 55); 
        
        
        nextPlatformPosD = nextPlatformPos + new Vector3(0,-5, 0); //create new platformPosition for FallenPlatform
        Instantiate(fallenPlatformPrefab, nextPlatformPosD, Quaternion.identity); //instantiate object
    }

    private void Update()
    {
        if (Vector3.Distance(nextPlatformPos, player.transform.position) < distanceThreshold)
        {
            GameObject plat = Instantiate(platformPrefab, nextPlatformPos, Quaternion.identity);
            // Add 3-5 obstacles within this plaform - randomly in both x & z direction
            for (int i = 0; i < 5; i++)
            {
                obstaclePrefab.transform.position = new Vector3(Random.Range(-2, 2), 1, Random.Range(-20, 20)); //randomize next platforms obstacles
                GameObject obs = Instantiate(obstaclePrefab, nextPlatformPos + obstaclePrefab.transform.position, Quaternion.identity);//based on the platform we have
                obs.transform.parent = plat.transform;// transform platform 
            }


            for(int i = 0; i < 2; i++){
                
                coinPrefab1.transform.position = new Vector3(Random.Range(-2, 2), 1, Random.Range(-20, 20)); //randomize next platforms obstacles
                GameObject coin1 = Instantiate(coinPrefab1, nextPlatformPos + coinPrefab1.transform.position, Quaternion.Euler(0, 0, -90));//based on the platform we have
                coin1.transform.parent = plat.transform;// transform platform 

                coinPrefab2.transform.position = new Vector3(Random.Range(-2, 2), 1, Random.Range(-20, 20)); //randomize next platforms obstacles
                GameObject coin2 = Instantiate(coinPrefab2, nextPlatformPos + coinPrefab2.transform.position, Quaternion.Euler(0, 0, -90));//based on the platform we have
                coin2.transform.parent = plat.transform;// transform platform 

                coinPrefab3.transform.position = new Vector3(Random.Range(-2, 2), 1, Random.Range(-20, 20)); //randomize next platforms obstacles
                GameObject coin3 = Instantiate(coinPrefab3, nextPlatformPos + coinPrefab3.transform.position, Quaternion.Euler(0, 0, -90));//based on the platform we have
                coin3.transform.parent = plat.transform;// transform platform 
            }
            nextPlatformPos += new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 55); //generate next position for platform
            
            nextPlatformPosD = nextPlatformPos + new Vector3(0,-5, 0); //create new platformPosition for FallenPlatform
            Instantiate(fallenPlatformPrefab, nextPlatformPosD, Quaternion.identity); //instantiate object
        }
    }
}
