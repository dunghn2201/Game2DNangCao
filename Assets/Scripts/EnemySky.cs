using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySky : MonoBehaviour
{
      public Player player;
    public int damage=1;
    public float speed=.5f;
    public float maxDistance=10;
    private Rigidbody2D rb2d;
    private float distance=0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        distance=0;
         player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }

    // Update is called once per frame
    void Update()
    {
      distance+=Time.deltaTime*2;
      if(distance>maxDistance){
          transform.localScale=new Vector2(-transform.localScale.x, transform.localScale.y);
          distance=0;
      }
      rb2d.velocity=new Vector2(-transform.localScale.x, 0)*speed;  
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
