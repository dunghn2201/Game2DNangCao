using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundManager : MonoBehaviour {
 
    public AudioClip coins;
 
    public AudioSource adisrc;
    // Use this for initialization
    void Start () {
        coins = Resources.Load<AudioClip>("Gamecoin");
        adisrc = GetComponent<AudioSource>();
 
    }
 
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

 
        }
    }
}