using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class crackercounter : MonoBehaviour {



    [SerializeField]
    private Text crackertext;

    private int schoor;

    public int Schoor
    {
        get
        {
            return schoor;
        }

        set
        {
           
            schoor = value;
            crackertext.text = "" + schoor;
        }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
