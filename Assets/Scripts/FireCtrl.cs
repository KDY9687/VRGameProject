
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject flameEffect;
    public Transform firePos;
    public Transform p1;
    public Transform p2;
    public Transform str;
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
            CreateFlame();
            SoundManager.instance.playSound("Shot");
            magazine--;
            OVRHapticsClip clip = new OVRHapticsClip();
            int iter = 40;
            int freq = 2;
            int str = 255;
            for(int i=0; i < iter; ++i)
            {
                clip.WriteSample(i % freq == 0 ? (byte)str : (byte)0);
            }
            OVRHaptics.LeftChannel.Preempt(clip);
            OVRHaptics.RightChannel.Preempt(clip);
        }
        else
        {
            SoundManager.instance.playSound("Empty gun");
        }
    }

    void CreateBullet()
    {
        str.position = p2.position;
        str.forward = p2.position - p1.position;
        str.Translate(0, 0, 1f);
        Instantiate(bullet, str);
    }
    void CreateFlame()
    {
        GameObject flame = (GameObject)Instantiate(flameEffect, firePos.position, firePos.transform.rotation);
        Destroy(flame, flame.GetComponent<ParticleSystem>().duration);
    }
}