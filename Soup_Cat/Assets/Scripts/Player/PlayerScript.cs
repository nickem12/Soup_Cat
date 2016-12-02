using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int crackers;
    public int lives;
    public int soupType = 0;
    private float invonable = 0;

    private bool lava = false;
    private bool alphegetti = false;
    private bool noddle = false;

    [SerializeField]
    private stat helth;

   // private Health hell;

    private void Awake()
    {
        helth.init();
    }

	// Use this for initialization
	void Start () {
        crackers = 0;
        lives = 9;
        //helth.
	}

  
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            soupType = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2) && lava)
        {
            soupType = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3) && alphegetti)
        {
            soupType = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4) && noddle)
        {
            soupType = 3;
        }

        if (invonable >= 0)
        {
            invonable -= Time.deltaTime;
        }
      

        //charlie worcking
        if (Input.GetKeyDown(KeyCode.P))
        {
            //hell.Valyou -= 10;
            hit();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
           // hell.Valyou += 10;
            helth.CurentHelth += 10;
        }

    }

    //cats
    public void hit()
    {
        if (invonable < 0)
        {
            invonable = 0;
        }

        if (invonable<=0)
        {
            helth.CurentHelth -= 10;
            invonable = 1;
        }

    }







}
