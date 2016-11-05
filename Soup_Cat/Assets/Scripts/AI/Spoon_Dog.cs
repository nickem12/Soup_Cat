using UnityEngine;
using System.Collections;

public class Spoon_Dog : MonoBehaviour {

    private int timer;
    private char direction;
    public int PATROL_DISTANCE;

    public enum MOOD_STATE { PATROL, FOLLOWING }
    public MOOD_STATE Mood;

	// Use this for initialization
	void Start ()
    {
        Mood = MOOD_STATE.PATROL;
        timer = 0;
        PATROL_DISTANCE = 50;
	}

    void move()
    {

        

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
        switch (Mood)
        {
            case MOOD_STATE.PATROL:
                {
                    timer++;

                    if (timer > PATROL_DISTANCE)
                    {
                        ChangeDirection();
                    }



                    break;
                }

            case MOOD_STATE.FOLLOWING:
                {


                    break;
                }
        }
	}
}
