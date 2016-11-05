using UnityEngine;
using System.Collections;

public class soupDrop : MonoBehaviour {

    float soupSpeed = 10;
    float dir;
    private GameObject player;

    private int counter = 20;

    enum soupType { normal, lava, alphegetti, noddle};

    soupType type;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = -player.transform.localScale.x;
        type = (soupType)player.GetComponent<PlayerScript>().soupType; 
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
