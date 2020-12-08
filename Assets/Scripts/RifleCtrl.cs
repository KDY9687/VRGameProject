using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleCtrl : MonoBehaviour
{
    public OVRGrabbable ovrg;
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrg.isGrabbed)
        {
            ovrg.Rcontrol(tr);
        }
    }
}
