using UnityEngine;
using System.Collections;

public class Owl : MonoBehaviour {

    public char direction;
    float velocity;
    float speed;
    private double timer;
    private double bombtimer;
    private bool facingRight = true;
    public int PATROL_DISTANCE;

    public Rigidbody2D bomb;
    public float bombSpeed;

    // Use this for initialization
    void Start () {
        timer = 0;
        bombtimer = 0;
        speed = 3;
        bombSpeed = -7;
	}

    void ChangeDirection()
    {
        timer = 0;

        if (direction == 'L')
        {
            direction = 'R';
        }
        else
        {
            direction = 'L';
        }
    }

    void move()
    {
        switch (direction)
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

    void DropBomb()
    {
        Rigidbody rocketClone = (Rigidbody)Instantiate(bomb, transform.position, transform.rotation);
        rocketClone.velocity = new Vector2(0,bombSpeed );
    }

    // Update is called once per frame
    void FixedUpdate () {
        timer += 0.5;
        bombtimer += 0.5;

        if (timer > PATROL_DISTANCE)
        {
            Debug.Log("changeDirection");
            ChangeDirection();
        }
        move();

        if (bombtimer > 10)
        {
            bombtimer = 0;
            DropBomb();
        }
    }
}
