using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    private Animator _animator;
    public GameObject OpenPanel = null;
    private bool nextToDrawer = false;

    void Start()
    {
        _animator = GetComponent<Animator>();    
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            nextToDrawer = true;
            // only show the 'E' overlay  if drawer is closed
            if(_animator.GetBool("open"))
            {
                OpenPanel.SetActive(false);    
            } 
            else
            {
                OpenPanel.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nextToDrawer = false;
            // _animator.SetBool("open", false);
            OpenPanel.SetActive(false);
        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }
    
    void Update()
    {
        if(nextToDrawer)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                if(_animator.GetBool("open")){
                    _animator.SetBool("open", false);
                }
                else{
                    _animator.SetBool("open", true);
                }
                
            }
        }
    }
}
