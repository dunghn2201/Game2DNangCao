using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Player : MonoBehaviour {
     public float speed = 80f, maxspeed = 5, maxjump = 7, jumpPow = 1200f;
    public bool grounded = true, faceright = true, doublejump = false;
public bool underWater=false;
    public  int ourHealth;
    public int maxHealth = 5;
    public Rigidbody2D r2;
    public Animator anim;
   public gamemaster gm;
    public SoundManager sound;

    public GameObject BulletToRight, BulletToLeft;
    Vector2 BulletPos;
    public float FireRate=0.5f;
    float NextFire=0.0f;

    // Use this for initialization
    void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D> ();
        anim = gameObject.GetComponent<Animator> ();
              gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        ourHealth = maxHealth;
          sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update () {
        anim.SetBool ("Grounded", grounded);
        anim.SetFloat ("Speed", Mathf.Abs (r2.velocity.x));

        if (Input.GetKeyDown (KeyCode.Space)) {
            if (grounded) {
                grounded = false;
                doublejump = true;
                r2.AddForce (Vector2.up * jumpPow);
            } else {
                if (doublejump) {
                    doublejump = false;
                    r2.velocity = new Vector2 (r2.velocity.x, 0);
                    r2.AddForce (Vector2.up * jumpPow * 2f);
                }
            }
        }

        if(Input.GetButtonDown("Fire1") && Time.time > NextFire){
            NextFire=Time.time+FireRate;
            Fire();
        }
    }
    

    void FixedUpdate () {
        float h = Input.GetAxis ("Horizontal");
        r2.AddForce ((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2 (maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2 (-maxspeed, r2.velocity.y);

        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2 (r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2 (r2.velocity.x, -maxjump);

        if (h > 0 && !faceright) {
            Flip ();
        }
        if (h < 0 && faceright) {
            Flip ();
        }
        if (grounded) {
            r2.velocity = new Vector2 (r2.velocity.x * 0.7f, r2.velocity.y);
        }
        // if (ourHealth <= 0) {
        //     Death ();
        // }

    }
void Fire(){
    BulletPos=transform.position;
    if(faceright){
        BulletPos += new Vector2(+1f, -0.55f);
        Instantiate(BulletToRight, BulletPos, Quaternion.identity);
    }else{
        BulletPos += new Vector2(-1f, -0.55f);
            Instantiate(BulletToLeft, BulletPos, Quaternion.identity);
    }
}

    public void Flip () {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    // public void Death () {
    //     SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    //      if (PlayerPrefs.GetInt("highscore") < gm.points)
    //         PlayerPrefs.SetInt("highscore", gm.points);
    // }

    public void Damage (int damage) {
        ourHealth -= damage;
        gameObject.GetComponent<Animation> ().Play ("redflash");
    }
    public void Knockback (float knockPow, Vector2 knockDir) {
        r2.velocity = new Vector2 (0, 0);
        r2.AddForce (new Vector2 (knockDir.x * -100, knockDir.y * knockPow));
    }
    private void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.CompareTag ("Coins")) {
             sound.Playsound("coins");
            Destroy(col.gameObject);
            gm.points += 1;
        }
           if (col.CompareTag("shoe"))
        {
           
            Destroy(col.gameObject);
            maxspeed = 6f;
            speed = 120f;
            StartCoroutine(timecount(5));
        }
 
        if (col.CompareTag("heart"))
        {

            Destroy(col.gameObject);
            ourHealth = 5;
        }
        if (col.gameObject.CompareTag ("water")) {
                 anim.SetBool ("UnderWater", !underWater);
                 
        }
    }
       IEnumerator timecount (float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = 5f;
        speed = 80f;
        yield return 0;
    }
       private void OnTriggerExit2D (Collider2D col) {
             if (col.gameObject.CompareTag ("water")) {
                 anim.SetBool ("UnderWater", underWater);
        }
       }

}