using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Movement

    public float speed;
    public float jump;
    float velocity;
    private bool facingRight = true;
    int jumpCounter = 0;
    //soup firing

    public Rigidbody2D soup;
    public float soupSpeed;

	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jumpCounter == 0)
            {
                jumpCounter++;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            }
            
        }
        if(Input.GetMouseButtonDown(0))
        {
            SpillSoup();
        }

        velocity = 0;

        if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            velocity = -speed;
            
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocity = speed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
        FlipSprite(velocity);
    }

    void SpillSoup()
    {
            Rigidbody rocketClone = (Rigidbody)Instantiate(soup, transform.position, transform.rotation);
            rocketClone.velocity = transform.forward * soupSpeed;
    }

    void FlipSprite(float dir)
    {
        if(dir<0 && facingRight || dir>0 && !facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = !facingRight;
        }
    }
    void OnTriggerEnter2D()
    {
        jumpCounter = 0;
    }
    //void OnTriggerEnter2D(Collider2D Col)
    //{
    //    if (Col.tag == "Enemy")
    //    {
    //        Destroy(gameObject);
    //    }
    //    //Detect collision between object A and object B

    //}
}
