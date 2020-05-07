using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
      public int Health = 100;
      public Player player;
    public int damage=1;
    public float speed;
    public bool MoveRight;
   // Start is called before the first frame update
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }
    // Update is called once per frame
    void Update()
    {
        if(MoveRight){
            transform.Translate(2*Time.deltaTime*speed,0,0);
            transform.localScale=new Vector2(-0.02f,0.02f);
        }else{
             transform.Translate(-2*Time.deltaTime*speed,0,0);
              transform.localScale=new Vector2(0.02f,0.02f);
        }
        //healt boss
          if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
      void Damage(int damage)
    {
        
        Health -= damage;
    }


     private void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.CompareTag ("Player")) {
            player.Damage (damage);
            player.Knockback (400f, player.transform.position);
        }
        if(col.gameObject.CompareTag("turnEnemy")){
    if(MoveRight){
        MoveRight=false;
    }else{
        MoveRight=true;
    }
}
    }
    
    private void OnTriggerStay2D (Collider2D col) {
        if (col.CompareTag ("Player")) {
            player.Knockback (800f, player.transform.position);
        }
    }
}
