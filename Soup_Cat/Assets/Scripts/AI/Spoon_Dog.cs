using UnityEngine;
using System.Collections;

public class Spoon_Dog : MonoBehaviour {

    private double timer;
    public char direction;
    public int PATROL_DISTANCE;
    private float jump;
    public GameObject player;
    Vector3 PlayerPos = new Vector3(0, 0, 0);
    Vector3 EnemyPos = new Vector3(0, 0, 0);

    float velocity;
    public float speed;

    public enum MOOD_STATE { PATROL, FOLLOWING };
    public MOOD_STATE Mood;

    private bool facingRight = true;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        Mood = MOOD_STATE.PATROL;
        timer = 0;
        jump = 250;
	}

   void OnTriggerEnter2D(Collider2D colider)
    {
        Debug.Log("collision detected");
        if(colider.gameObject.tag == "ground")
        {
            Debug.Log("jumping");
            Vector2 newVelocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            GetComponent<Rigidbody2D>().AddForce(newVelocity);
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
        PlayerPos = player.transform.position;
        EnemyPos = this.GetComponent<Transform>().position;

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

                    if ((PlayerPos.x - EnemyPos.x) > 200 || (PlayerPos.x - EnemyPos.x) < 200)
                    {
                        Mood = MOOD_STATE.FOLLOWING;
                    }
                    break;
                }
            case MOOD_STATE.FOLLOWING:
                {
                    if (PlayerPos.x > EnemyPos.x)
                    {
                        direction = 'R';
                    }
                    else if(PlayerPos.x < EnemyPos.x)
                    {
                        direction = 'L';
                    }
                    move();
                    break;
                }
        }
	}
}
