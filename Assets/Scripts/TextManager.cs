using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Transform rifleTr;
    public Text text;
    public FireCtrl fCtr;
    public OVRGrabbable ovrg;
    // Update is called once per frame
    void Update()
    {
        if (fCtr.magazine == 0)
            text.text = "탄창을 교체 하십시오";
        if (ovrg.isGrabbed == false)
            text.text = "총을 잡으십시오";
        else if(fCtr.magazine != 0)
            text.text = "정조준 후, 숨을 참고 사격하십시오";
        if (rifleTr.rotation.eulerAngles.y < 135f || rifleTr.rotation.eulerAngles.y > 225f)
        {
            text.text = "총구는 정면을 향하십시오";
            OVRHapticsClip clip = new OVRHapticsClip();
            int iter = 40;
            int freq = 2;
            int str = 255;
            for (int i = 0; i < iter; ++i)
            {
                clip.WriteSample(i % freq == 0 ? (byte)str : (byte)0);
            }
            OVRHaptics.LeftChannel.Preempt(clip);
            OVRHaptics.RightChannel.Preempt(clip);
        }
        Debug.Log(rifleTr.rotation.eulerAngles.y);
    }
}
