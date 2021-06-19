using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] public GameObject ObjectInteractPanel = null;
    [SerializeField] public GameObject ObjectPanel = null;

    public int itemsInBackpack = 0;
    private bool backpackEquiped;
    public bool haveBatteries = false;
    public bool haveNote = false;
    public bool havePhoto = false;

    private bool IsObjectInteractPanelActive
    {
        get{return ObjectInteractPanel.activeInHierarchy;}
    }

    private BoxCollider[] myColliders;
    private MeshRenderer myRenderer;

    void Start()
    {
        // get the mesh and colliders of the object so we can hide them when collected
        myColliders = gameObject.GetComponents<BoxCollider>();
        myRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        // get value of hasBackpack from DrawerOpen script
        backpackEquiped = GameObject.Find("drawer").GetComponent<DrawerOpen>().hasBackpack;

        if(IsObjectInteractPanelActive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {          
                addItemToBackPack();
            }
        }
    }

    void addItemToBackPack()
    {
        // hide ineteract panel
        ObjectInteractPanel.SetActive(false);
        
        // hide the batteries object
        myRenderer.enabled = false;
        foreach(BoxCollider bc in myColliders) bc.enabled = false;

        // increase item count
        itemsInBackpack ++;
        
        // run collected item coroutine
        StartCoroutine(BatteriesCollected());
    }

    void OnTriggerEnter(Collider other) 
    {
        if(backpackEquiped)
        {
            if(other.tag == "Player")
            {
                ObjectInteractPanel.SetActive(true);
            }
        }
        
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player")
        {
            ObjectInteractPanel.SetActive(false);
        }
    }

    IEnumerator BatteriesCollected()
    {
        // show batteries collected message for 3 seconds
        ObjectPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        ObjectPanel.SetActive(false);
    }
}
