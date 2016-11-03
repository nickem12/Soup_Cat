using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Movement

    public float speed;
    public float jump;
    float velocity;

    int jumpCounter = 0;

	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jumpCounter == 0)
            {
                jumpCounter++;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            }
            
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
    }

    void OnTriggerEnter2D()
    {
        jumpCounter = 0;
    }
}
