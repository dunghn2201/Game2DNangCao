using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
        public Player player;
    public int damage=3;
    public float speedball=30;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity=new Vector2(speedball,0);
            player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }
  private void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag ("Player")) {
            player.Damage (damage);
            player.Knockback (600f, player.transform.position);
        }
    }
    
    private void OnTriggerStay2D (Collider2D col) {
        if (col.CompareTag ("Player")) {
            player.Knockback (600f, player.transform.position);
        }
    }

}
