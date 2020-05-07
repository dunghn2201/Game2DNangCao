using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public Player player;
    public int damage=1;
    // Start is called before the first frame update
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag ("Player")) {
            player.Damage (damage);
            player.Knockback (400f, player.transform.position);
        }
    }
    
    private void OnTriggerStay2D (Collider2D col) {
        if (col.CompareTag ("Player")) {
            player.Knockback (800f, player.transform.position);
        }
    }
}