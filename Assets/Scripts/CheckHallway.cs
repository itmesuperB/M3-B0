using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHallway : MonoBehaviour
{
    
    public bool doorEnabled = false;
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Walker")
        {
            doorEnabled = true;
            Debug.Log("Infront of door");
        }
        
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Walker")
        {
            doorEnabled = false;
            Debug.Log("NOT infront of door");
        }
    }
}
