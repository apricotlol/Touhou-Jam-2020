using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Band : MonoBehaviour
{

    public int health = 200;
    private string state = "singer";

    public string getBandState()
    {
        return state;
    }

    public void setBandState(string newState)
    {
        state = newState;
    }
    public bool updateHealth(int updateValue)
    {
        health = health + updateValue;
        if(health <= 0) return true;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
