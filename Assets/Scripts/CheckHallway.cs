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

    void OnTriggerStay(Collider other) {
        // check cat is near door
        if(other.tag == "Player")
        {
            if(doorEnabled)
            {
                if(Input.GetKeyDown(KeyCode.M))
                {
                    // meow heard
                    meowHeard = true;
                    // stop guy from walking
                    // play door open animation
                    // start endgame credit
                    Debug.Log("YOU DID IT");
                }
            }
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Walker")
        {
            doorEnabled = false;
        }
    }
}
