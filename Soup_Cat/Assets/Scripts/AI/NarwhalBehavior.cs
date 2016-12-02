using UnityEngine;
using System.Collections;

public class NarwhalBehavior : MonoBehaviour {

    public GameObject player;
    float distance = 0;
    float velocity;
    float YMax;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        velocity = 10;
        YMax = transform.position.y + 4;
    }
	
	// Update is called once per frame
	void Update ()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance < 5)
        {
            if (transform.position.y < YMax)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, velocity);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            }
        }
	}
}
