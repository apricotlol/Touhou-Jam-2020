using UnityEngine;

//Author: (N/A)

//changed all Vector3 to Vector2
public class BlackHoleActions : MonoBehaviour
{
    [SerializeField]
    Transform blackhole;
    [SerializeField]
    float movementSnappiness;
    [SerializeField]
    float eatRadius;
    [SerializeField]
    float objectsEatenPerSecond;
    [SerializeField]
    Sprite[] blackHoleSprites;

    float initialz; //for movement purposes
    float initialTime;
    float lastEatTime;
    Vector2 destination = Vector2.zero;//Initalized to zero, also whatever it was named before was terrible -ApricotLOL

    private GameObject[] objectsToDestroy;


    private Vector2 refVel = Vector2.zero;// intilize reference velocity to zero -ApricotLOL
    void Start()
    {
        initialTime = Time.time;
        lastEatTime = Time.time;
        objectsToDestroy = new GameObject[(int)objectsEatenPerSecond];
    }
    public void gotopos(Vector2 position)// Goes to position(for E and Z spell)
    {
        destination = position;//position arguement becomes the destination for the GameObject
        return;

    }

    public void FixedUpdate()
    {
        destroyEatenObjects();

    }


    public void eat(bool forceEat)// eats objects in radius
    {
        float secondsBetweenEating = 1 / objectsEatenPerSecond;
        bool ate = false;

        Collider2D[] eatableCollisions = Physics2D.OverlapCircleAll(transform.position, eatRadius);
        foreach (Collider2D c in eatableCollisions)
        {
            if ((secondsBetweenEating <= Time.time - lastEatTime) || forceEat)
            {
                if (c.transform != this.transform)
                {
                    if (c.GetComponent<SelfCounting>() != null)
                    {//made sure that objects that are counted toward the score system are eaten
                        //SelfCounting Objects will count towards gameManager.foodBlackHole (int)
                        //If the object doesn't have the script then it's not foodBlackHole
                        //this is will help us debug
                        //so if the Blackhole isn't eating the object then the object wasn't counted
                        //-ApricotLOL
                        if (forceEat) Debug.Log("Ate");
                        forceEat = false;
                        for (int i = 0; i < objectsToDestroy.Length; i++)
                        {
                            if (objectsToDestroy[i] == null)
                            {
                                objectsToDestroy[i] = c.gameObject;
                                //disable collider to stop being prevented from being sucked due to other objects
                                c.enabled = false;
                                //disable velocity for position control
                                break;
                            }
                        }
                        lastEatTime = Time.time;
                        ate = true;
                        Vector3 velPos = Vector3.zero;
                    }

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
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;//~!o
    }

    public void chase(Transform objT)
    {
        gotopos(objT.position);
    }

    public void destroyEatenObjects()
    {
        for (int i = 0; i < objectsToDestroy.Length; i++)
        {
            if (objectsToDestroy[i] != null)
            {
                objectsToDestroy[i].transform.position = Vector2.Lerp(objectsToDestroy[i].transform.position, transform.position, 2 * Time.fixedDeltaTime);
                objectsToDestroy[i].transform.localScale = Vector2.Lerp(objectsToDestroy[i].transform.localScale, Vector2.zero, 2 * Time.fixedDeltaTime);
                if (Vector3.Distance(objectsToDestroy[i].transform.position, transform.position) < 5f)
                {
                    Destroy(objectsToDestroy[i].gameObject);
                    objectsToDestroy[i] = null;
                }
            }
        }
    }

    void updateAnimation()
    {
        int moodIndex = GetComponent<JankMachine>().checkMood();
        //int moodIndex = 1;
        int rateOfAnim = 30;
        int sizeIndex = (int)Mathf.Min(2, (Time.time - initialTime) / 15);
        GetComponent<SpriteRenderer>().sprite = blackHoleSprites[12 * sizeIndex + 4 * moodIndex + (int)(Time.time * rateOfAnim) % 4];
    }

    //constantly eating surroundings
    void Update()
    {
        updateAnimation();

        blackhole.position = Vector2.SmoothDamp(blackhole.position, new Vector2(destination.x, destination.y), ref refVel, 1 / movementSnappiness);
        //fixed the arguments to Vector2,
        //arg1: Current Position
        //arg2: Cordinates of destination
        //arg3: reference velocity
        //arg4: Smoothing rate
        //-ApricotLOL
        eat(false);
    }

}
