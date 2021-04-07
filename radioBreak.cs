using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioBreak : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip song, breakSound;
    bool broken = false;
    public LayerMask breaksRadio;

    private void OnCollisionEnter(Collision collision)
    {
        if (!broken && collision.relativeVelocity.magnitude > 5 && collision.collider.gameObject.layer == 9)
        {
            audio.Stop();
            audio.PlayOneShot(breakSound);
            broken = true;
        }
    }
}
