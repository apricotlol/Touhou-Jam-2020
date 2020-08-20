using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ : MonoBehaviour
{

    public new AudioSource audio;
    GameManager gm;
    public GameObject blackHole;
    public GameObject player;

    public AudioClip a;
    public AudioClip b;
    public AudioClip c;
    public AudioClip d;
    public AudioClip e;
    public AudioClip f;

    void Start()// somethign to start with
    {
        audio.Stop();
        audio.PlayOneShot(a, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
