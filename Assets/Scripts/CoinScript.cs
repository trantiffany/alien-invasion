using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(90 * 2 * Time.deltaTime, 0, 0); //rotate the object
    }

    private void OnTriggerEnter(Collider other){
        if(other.name == "Player"){ //if the object collides with player
            Destroy(gameObject); //destory object
        }
    }
}
