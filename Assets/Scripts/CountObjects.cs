using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObjects : MonoBehaviour
{
    public int objectsInBackpack = 0;
    private int haveBatteries;
    private int haveNote;
    private int havePhoto;
    void Update()
    {
        // Check if batteries are collected
        haveBatteries = GameObject.Find("batteries").GetComponent<ObjectCollector>().itemsInBackpack;
        // Check if batteries are collected
        haveNote = GameObject.Find("sticky note").GetComponent<ObjectCollector>().itemsInBackpack;
        // Check if batteries are collected
        havePhoto = GameObject.Find("photo").GetComponent<ObjectCollector>().itemsInBackpack;
        objectsInBackpack = haveBatteries + haveNote + havePhoto;
    }
}
