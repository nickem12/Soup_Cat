using UnityEngine;
using System.Collections;

public class Nawhal : MonoBehaviour {

    float distance;
    float velocity;
    GameObject player;
    float YMax;
    public short Health;
    public short damage;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        YMax = transform.position.y + 4;
        velocity = 10;
        Health = 200;
        damage = 20;
	}
	
	// Update is called once per frame
	void Update ()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
	    if (distance < 5)
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
