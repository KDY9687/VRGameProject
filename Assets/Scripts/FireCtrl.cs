
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject flameEffect;
    public Transform firePos;
    public Transform flamePos;
    public OVRGrabbable grabScript;

    public int ammoCount;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) ||
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            Fire();
        }
        if (Input.GetMouseButtonUp(0))
        { // Test용
            Fire();
        }

        if (grabScript.reload)
        {
            if(ammoCount != 8)
                Reloading();
            grabScript.reload = false;
        }
    }

    void Fire()
    {
        if (grabScript.isGrabbed && ammoCount != 0)
        {
            SoundManager.instance.playSound("Shot");
            CreateBullet();
            CreateFlame();
            ammoCount -= 1;
        }
        else if (grabScript.isGrabbed)
        {
            SoundManager.instance.playSound("Empty gun");
        }
    }

    void Reloading()
    {
        SoundManager.instance.playSound("Reloading");
        ammoCount = 8;
    }

    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
    
    void CreateFlame()
    {
        GameObject flame = (GameObject)Instantiate(flameEffect, flamePos.position, flamePos.transform.rotation);
        Destroy(flame, flame.GetComponent<ParticleSystem>().duration);
    }
    
}