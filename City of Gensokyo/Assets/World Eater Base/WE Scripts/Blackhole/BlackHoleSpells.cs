using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpells : MonoBehaviour
{
    [SerializeField]
    Transform blackhole;
    [SerializeField]
    float movementSnappiness;
    [SerializeField]
    float eatRadius;
    [SerializeField]
    float objectsEatenPerSecond;

    float initialz; //for movement purposes
    float lastEatTime;
    
    void Start()
    {
        initialz = blackhole.position.z;
        lastEatTime = Time.time;
    }
    public void gotopos(Vector2 position)// Goes to position(for E and Z spell)
    {
        Vector3 velPos = Vector3.zero;
        blackhole.position = Vector3.SmoothDamp(blackhole.position, new Vector3(position.x,position.y,initialz), ref velPos, 1 / movementSnappiness) ;
        return;

    }
    public void eat()// eats objects in radius
    {
        float secondsBetweenEating = 1 / objectsEatenPerSecond;
        bool ate = false;

        Collider2D[] eatableCollisions = Physics2D.OverlapCircleAll(transform.position, eatRadius);
        foreach (Collider2D c in eatableCollisions)
        {
            if(secondsBetweenEating <= Time.time - lastEatTime)
            {
                //prevent black hole from eating itself xD
                if(c.transform != this.transform)
                {
                    Destroy(c.gameObject);
                    lastEatTime = Time.time;
                    ate = true;
                    Vector3 velPos = Vector3.zero;
                    c.transform.localScale = Vector3.SmoothDamp(c.transform.localScale, Vector3.zero, ref velPos, 0.1f);
                }
            }
        }

        if (ate)
        {
            lastEatTime = Time.time;
        }
    }
    public void stop() //BH stops moving
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void chase(Transform objT)
    {
        gotopos(objT.position);
    }

    //constantly eating surroundings
    void Update()
    {
        eat();
    }
}
