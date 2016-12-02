using UnityEngine;
using System.Collections;

public class stat
{
    private Health hell;
    private float MaxValyou;
    private float curentHelth;

    public float CurentHelth
    {
        get
        {
            return curentHelth;
        }

        set
        {

            curentHelth = value;
            hell.Valyou = curentHelth;
        }
    }

    public float MaxValyou1
    {
        get
        {
            return MaxValyou;
        }

        set
        {
            MaxValyou = value;
            hell.MaxValyou = MaxValyou;
        }
    }
}
