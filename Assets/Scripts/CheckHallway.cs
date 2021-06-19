using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHallway : MonoBehaviour
{
    
    public bool doorEnabled = false;
    public bool meowHeard = false;
    void OnTriggerEnter(Collider other) 
    {
        // check person in hallway in near door
        if(other.tag == "Walker")
        {
            doorEnabled = true;
        }       
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Walker")
        {
            doorEnabled = false;
        }
    }

    void OnTriggerStay(Collider other) {
        // check cat is near door
        if(other.tag == "Player")
        {
            if(doorEnabled && Input.GetKeyDown(KeyCode.M))
            {
                // meow heard
                meowHeard = true;
                // doorOpen script runs
                // Hallwaywalker script triggers to stop the walking
                // start endgame credit
                Debug.Log("YOU DID IT");
                
            }
        }
    }

    
}
