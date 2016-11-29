using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField]
    private float Healthremaining;

    [SerializeField]
    private Image helth;

    public float MaxValyou { get; set; }

    public float valyou
    {
        set
        {
            Healthremaining = HelthMath(valyou, 0, MaxValyou, 0, 1);
        }

    }


    // Use this for initialization
    void Start ()
    {
	
	}
	

	// Update is called once per frame
	void Update ()
    {
        HelthBarStuff();
    }


    private void HelthBarStuff()
    {

        helth.fillAmount = Healthremaining;

    } 

    private float HelthMath(float valyou, float inMin, float inMax, float outMax, float outMin)
    {

        return ((valyou - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);

    }
}
