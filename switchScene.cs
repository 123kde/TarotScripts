using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip transitionSound;
    public float _fadeDuration = 2.5f;
    public int scene;

    public void LetsGo()
    {
        audio.PlayOneShot(transitionSound);
        FadeToWhite();
        Invoke("ActuallySwitchScene", 3);
    }

    void ActuallySwitchScene()
    {
        SceneManager.LoadScene(scene);
    }

    //following 2 functions taken from:https://answers.unity.com/questions/1258342/steam-vr-fade-camera.html, answer by dsentence
    private void FadeToWhite()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        SteamVR_Fade.Start(Color.white, _fadeDuration);
    }

    private void FadeFromWhite()
    {
        SteamVR_Fade.Start(Color.white, 0f);
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }
}
