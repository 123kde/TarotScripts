using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class fadeIn : MonoBehaviour
{
    public float _fadeDuration = 2.5f;

    void Start()
    {
        SteamVR_Fade.Start(Color.white, 0f);
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }
}
