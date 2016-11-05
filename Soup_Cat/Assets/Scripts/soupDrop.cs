using UnityEngine;
using System.Collections;

public class soupDrop : MonoBehaviour {

    float soupSpeed = 10;
    float dir;
    private GameObject player;

    private int counter = 20;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = -player.transform.localScale.x;
    }
	// Update is called once per frame
	void Update ()
    {
        counter--;
        if(counter<=0)
        {
            Destroy(gameObject);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir * soupSpeed, GetComponent<Rigidbody2D>().velocity.y);

	}
}
