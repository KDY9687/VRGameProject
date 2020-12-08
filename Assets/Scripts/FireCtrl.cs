
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    // public GameObject flameEffect;
    public Transform firePos;
    //public Transform flamePos;
    public int magazine = 0;

    public OVRGrabbable ovrg;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            if(ovrg.isGrabbed)
                Fire();
        }
    }

    void Fire()
    {
        if (magazine > 0)
        {
            CreateBullet();
            magazine--;
        }
       // CreateFlame();
    }

    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
    /*
    void CreateFlame()
    {
        GameObject flame = (GameObject)Instantiate(flameEffect, flamePos.position, flamePos.transform.rotation);
        Destroy(flame, flame.GetComponent<ParticleSystem>().duration);
    }
    */
}