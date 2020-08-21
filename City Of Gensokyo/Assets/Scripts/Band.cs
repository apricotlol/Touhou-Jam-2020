using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Band : MonoBehaviour
{

    public int health = 200;
    public string b_name;
    private string state = "null";

    //have audio clips



    public string getBandMember()
    {
        return state;
    }

    public void setBandMember(string newState)
    {
        state = newState;
    }
    public bool updateHealth(int updateValue)
    {
        health = health + updateValue;
        Debug.Log(b_name + "HP is at" + health);
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
