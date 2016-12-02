using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField]
    private float Healthremaining;

    [SerializeField]
    private Image helth;

    public float ChangeHelth;

    public float MaxValyou { get; set; }
    [SerializeField]
    private float valyou=100;

    public float Valyou
    {
        get
        {
            return valyou;
        }

        set
        {
            valyou = value;
            Debug.Log(valyou);
            Healthremaining = HelthMath(valyou, 0, MaxValyou, 0, 1);
        }
    }

  


    // Use this for initialization
    void Start ()
    {
       // Valyou = 2;
	}
	

	// Update is called once per frame
	void Update ()
    {
        HelthBarStuff();
    }


    private void HelthBarStuff()
    {

        if (Healthremaining!= helth.fillAmount)
        {
            helth.fillAmount = Healthremaining;
        }
        

    } 

    private float HelthMath(float Valyou, float inMin, float inMax, float outMax, float outMin)
    {
        return  (Valyou / inMax);
        // return ((Valyou - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);

    }
}
