using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdTrigger : MonoBehaviour
{
    public float releaseTreshold; //also in seconds
    public Sprite[] spritesanim; //the sprites for the destruction animation
    Rigidbody2D body; 
    public bool released; 
    float releasetimer;//in seconds
    SpriteRenderer spriteren;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteren = GetComponent<SpriteRenderer>();
        releasetimer = 0;
        body.bodyType = RigidbodyType2D.Static;
        if (spritesanim == null || spritesanim.Length == 0) spritesanim = new Sprite[1] {spriteren.sprite};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BlackHole")
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            if (body.drag > 1 && released) body.drag = 0;
            else if (body.drag > 1) releasetimer += Time.deltaTime;
            if (releasetimer > releaseTreshold)
            {
                released = true;
            }
            for(int i = 0; i<spritesanim.Length; i++)
            {
                if(releasetimer>releaseTreshold*i/spritesanim.Length)
                {
                    spriteren.sprite = spritesanim[i];
                }
            }
        }
    }
}
