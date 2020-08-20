using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    
    [SerializeField]
    float cooldownE = 2; //cooldowns
    [SerializeField]
    float cooldownQ = 2;
    [SerializeField]
    float cooldownR = 2;
    [SerializeField]
    float cooldownZ = 2;
    [SerializeField]
    float MaxManaPoints = 100;
    [SerializeField]
    int recoverManaPoints = 1; //the amount of MP that the player regenerates per sec.
    [SerializeField]
    int manaCostE = 10;
    [SerializeField]
    int manaCostQ = 10;
    [SerializeField]
    int manaCostR = 10;
    [SerializeField]
    int manaCostZ = 10;
    float[] cooldownsTimer; // will keep track of the cooldowns
    BlackHoleActions blackhole;
    public float manaPoints;

    // Start is called before the first frame update
    void Start()
    {
        blackhole = GameObject.Find("BlackHole").GetComponent<BlackHoleActions>();
        cooldownsTimer = new float[4]
        { 
            cooldownE,
            cooldownQ,
            cooldownR,
            cooldownZ 
        };
        manaPoints = MaxManaPoints;
    }
    
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<4; i++) //Handle cooldowns
        {
            if(cooldownsTimer[i] > 0.0f)
            {
                cooldownsTimer[i] -= Time.deltaTime;
            }
        }
        if(manaPoints < MaxManaPoints)
        {
            manaPoints += Time.deltaTime* recoverManaPoints;
        }
        if(Input.GetKey(KeyCode.E) && cooldownsTimer[0] <= 0 && manaPoints>=manaCostE)
        {
            blackhole.gotopos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            cooldownsTimer[0] = cooldownE;
            manaPoints -= manaCostE;
            Debug.Log("Mana: " + manaPoints);
        }
        if (Input.GetKey(KeyCode.Q) && cooldownsTimer[1] <= 0 && manaPoints >= manaCostQ)
        {
            blackhole.eat(true);
            cooldownsTimer[1] = cooldownQ;
            manaPoints -= manaCostQ;
            Debug.Log("Mana: " + manaPoints);
        }
        if (Input.GetKey(KeyCode.R) && cooldownsTimer[2] <= 0 && manaPoints >= manaCostR)
        {
            blackhole.stop();
            cooldownsTimer[2] = cooldownR;
            manaPoints -= manaCostR;
            Debug.Log("Mana: " + manaPoints);
        }
        if (Input.GetKey(KeyCode.Z) && cooldownsTimer[3] <= 0 && manaPoints >= manaCostZ)
        {
            blackhole.gotopos(transform.position);
            cooldownsTimer[3] = cooldownZ;
            manaPoints -= manaCostZ;
            Debug.Log("Mana: " + manaPoints);
        }
    }

    public float getmana() { //Jank Machine needs to interface -ApricotLOL
        return manaPoints; 
    }
}
