using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
   public GameObject playerr;

    public Player player;
 
    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
 
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false){
             player.grounded = true;
        }
if(collision.gameObject.CompareTag("MovingPlat")){
     player.grounded = true;
     playerr.transform.parent=collision.gameObject.transform;
}
         
    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = true;
           
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water")){
                    player.grounded = false;
        }
    
if(collision.gameObject.CompareTag("MovingPlat")){
    playerr.transform.parent=null;
}

    }
}
