using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator _animator;
    private bool meowHeard = false;

    void Start()
    {
        _animator = GetComponent<Animator>();    
    }
    
    void Update()
    {
        meowHeard = GameObject.Find("HallwayCheck").GetComponent<CheckHallway>().meowHeard;
        Debug.Log("animator: " + _animator.GetBool("open"));
        if(meowHeard)
        {
            _animator.SetBool("open", true);
            
        }
        
    }

    // IEnumerator GetBackpack()
    // {
    //     // show backpack collected message for 3 seconds
    //     yield return new WaitForSeconds(1);
    //     BackpackPanel.SetActive(true);
    //     yield return new WaitForSeconds(3);
    //     BackpackPanel.SetActive(false);
    // }
}
