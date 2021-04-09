using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class switchScene : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip transitionSound;
    public float _fadeDuration = 2.5f;

    public void LetsGo()
    {
        audio.PlayOneShot(transitionSound);
        FadeToWhite();
        Invoke("ActuallySwitchScene", 3);
    }


    void ActuallySwitchScene()
    {
        FadeFromWhite();
        //switchscene
    }

    //following 2 functions taken from:https://answers.unity.com/questions/1258342/steam-vr-fade-camera.html, answer by dsentence

    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, _fadeDuration);
    }
    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeFromWhite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
