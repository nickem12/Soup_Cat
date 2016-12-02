using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField]
    private float Healthremaining;

    [SerializeField]
    private Image helth;
    public float ChangeHelth;
    private float lurpspees=2;

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
            helth.fillAmount = Mathf.Lerp(helth.fillAmount ,Healthremaining,Time.deltaTime*lurpspees);
        }
        

    } 

    private float HelthMath(float Valyou, float inMin, float inMax, float outMax, float outMin)
    {
        return  (Valyou / inMax);
        // return ((Valyou - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);

    }
}
