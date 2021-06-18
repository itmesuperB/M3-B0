using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] public GameObject OpenPanel = null;
    [SerializeField] public GameObject BackpackPanel = null;
    private bool nextToDrawer = false;
    public bool hasBackpack = false;

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
                if(!hasBackpack)
                {
                    StartCoroutine(GetBackpack()); // need coroutine to use WaitForSeconds()
                    // TODO: add backpack noise
                    // TODO: add playerwearingbackpack functionality
                    hasBackpack = true;
                }
                
                if(_animator.GetBool("open")){
                    _animator.SetBool("open", false);
                }
                else{
                    _animator.SetBool("open", true);
                }
            }
        }
    }

    IEnumerator GetBackpack()
    {
        // show backpack collected message for 3 seconds
        yield return new WaitForSeconds(1);
        BackpackPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        BackpackPanel.SetActive(false);
    }
}
