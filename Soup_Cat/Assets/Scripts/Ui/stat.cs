using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class stat
{
    [SerializeField]
    private Health hell;
    [SerializeField]
    private float maxValyou=100;
    [SerializeField]
    private float curentHelth=100;

    public float CurentHelth
    {
        get
        {
            return curentHelth;
        }

        set
        {

            curentHelth = Mathf.Clamp(value,0, maxValyou);
            hell.Valyou = curentHelth;
        }
    }

    public float MaxValyou1
    {
        get
        {
            return maxValyou;
        }

        set
        {
            //hell.MaxValyou = maxValyou;
            this.maxValyou = value;
            hell.MaxValyou = maxValyou;
        }
    }

   public void init()
    {
        this.MaxValyou1 = 100;
      //  this.CurentHelth = curentHelth;

    }
}
