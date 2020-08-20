using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Band : MonoBehaviour
{

    private int health;
    private int energy;

    public Band()
    {
        health = 200;
        energy = 100;
    }

    public int getEnergy()
    {
        return energy;
    }

    public void updateEnergy(int updateValue)
    {
        energy = energy + updateValue;
    }

    public void updateHealth(int updateValue)
    {
        health = health + updateValue;
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
