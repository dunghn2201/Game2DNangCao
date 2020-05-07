using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
        public int dmg=20;
    public float velX=5f;
    float velY=0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(velX, velY);
        Destroy(gameObject, 2f);
    }
    private void OnTriggerStay2D(Collider2D col){
    if(col.isTrigger!=true &&col.CompareTag("Enemy")){
        col.SendMessageUpwards("Damage",dmg);
         Destroy(gameObject);
    }

}
}
