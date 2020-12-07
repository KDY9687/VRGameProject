using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip Shot;
    public AudioClip Reloading;
    public AudioClip EmptyGun;
    public AudioClip ZombieSound;

    AudioSource myaudio;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        myaudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void playSound(string audioName)
    {
        if(audioName == "Shot")
        {
            myaudio.PlayOneShot(Shot);
            Debug.Log("슛사운드 재생");
        }
        if(audioName == "Reloading")
        {
            myaudio.PlayOneShot(Reloading);
            Debug.Log("장전 재생");
        }
        if(audioName == "Empty gun")
        {
            myaudio.PlayOneShot(EmptyGun);
            Debug.Log("빈총 재생");
        }
        if (audioName == "ZombieSound")
        {
            myaudio.PlayOneShot(ZombieSound);
            Debug.Log("좀비 커트");
        }
    }

}
