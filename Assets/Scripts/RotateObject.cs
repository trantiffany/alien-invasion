using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script attached to model on title screen
public class RotateObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        transform.Rotate(Vector3.one * 4 * (2 *Time.deltaTime)); //rotate object 
    }

}