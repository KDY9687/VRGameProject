using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineCtrl : MonoBehaviour
{
    public OVRGrabbable ovrg;
    public Transform tr;
    public Transform rTr;
    public bool attached = false;
    public FireCtrl fCtrl;
    int magazine = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrg.isGrabbed)
        {
            ovrg.Mcontrol(tr);
            if (attached)
            {
                attached = false;
                magazine = fCtrl.magazine;
                fCtrl.magazine = 0;
            }
        }
        else if(Vector3.Distance(tr.position, new Vector3(rTr.position.x, rTr.position.y, rTr.position.z)) < 0.05f)
        {
            attached = true;
            fCtrl.magazine = magazine;
        }

        if (attached)
        {
            tr.position = rTr.position;
            tr.rotation = rTr.rotation;
        }
    }
}
