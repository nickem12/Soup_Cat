using UnityEngine;
using System.Collections;

public class Spoon_Dog : MonoBehaviour {

    private double timer;
    public char direction;
    public int PATROL_DISTANCE;
    private float jump;
    public short jumpCounter;
    public GameObject player;
    float distance = 0;
    public short Health;
    public short damage;

    float velocity;
    float speed;

    public enum MOOD_STATE { PATROL, FOLLOWING };
    public MOOD_STATE Mood;

    private bool facingRight = true;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        Mood = MOOD_STATE.PATROL;
        timer = 0;
        jump = 40;
        jumpCounter = 0;
        Health = 50;
        speed = 2;
        Health = 20;
        damage = 5;
	}

   void OnTriggerEnter2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "ground" && jumpCounter != 0)
        {
            jumpCounter = 0;
        }

        if(colider.gameObject.tag == "JumpThing")
        {
            if (jumpCounter == 0)
            {
                Vector2 newVelocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                GetComponent<Rigidbody2D>().AddForce(newVelocity);
                jumpCounter = 1;
            }
        }
    }

    //points sprite in right direction
    void FlipSprite(float dir)
    {
        if (dir < 0 && facingRight || dir > 0 && !facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = !facingRight;
        }
    }

    //moves the character
    void move()
    {
        switch(direction)
        {
            case 'R':
                velocity = speed;
                break;

            case 'L':
                velocity = -speed;
                break;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
        FlipSprite(-velocity);
    }

    //changes the direction the character is moving
    void ChangeDirection()
    {
        timer = 0;
        
        if(direction == 'L')
        {
            direction = 'R';
        }
        else
        {
            direction = 'L';
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        distance = Vector3.Distance(player.transform.position, this.GetComponent<Transform>().position);

        switch (Mood)
        {
            case MOOD_STATE.PATROL:
                {
                    timer += 0.5;

                    if (timer > PATROL_DISTANCE)
                    {
                        ChangeDirection();
                    }

                    move();

                    if (distance < 7)
                    {
                        Mood = MOOD_STATE.FOLLOWING;
                    }
                    break;
                }
            case MOOD_STATE.FOLLOWING:
                {
                    if (player.transform.position.x > this.GetComponent<Transform>().position.x)
                    {
                        direction = 'R';
                    }
                    else if (player.transform.position.x < this.GetComponent<Transform>().position.x)
                    {
                        direction = 'L';
                    }
                    move();
                    if (distance > 10)
                    {
                        Mood = MOOD_STATE.PATROL;
                    }
                    break;
                }
        }
	}
}
