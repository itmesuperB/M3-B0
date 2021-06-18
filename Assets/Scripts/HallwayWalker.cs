using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayWalker : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 10f;
    float movementFactor;
    private int itemsInBackpack;
    
    
    void Start()
    {
        startingPos = transform.position;
    }
    void StartWalk()
    {
        if (period <= Mathf.Epsilon) {return;} // protect against NAN errors
        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283 (tau)
        float rawSinWave = Mathf.Sin( cycles * tau ); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }

    void Update() {
        itemsInBackpack = GameObject.Find("Backpack").GetComponent<CountObjects>().objectsInBackpack;

        if(itemsInBackpack == 3)
        {
            StartWalk();
        }
    }

    
}
