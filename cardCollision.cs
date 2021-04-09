using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCollision : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip cardSoundClip;
    public double soundMagnitude = 0.75;
    public float knockCooldown = 0.05f;
    float originalKnockCooldown;

    private void OnCollisionEnter(Collision collision)
    {
        if (knockCooldown <= 0 && collision.relativeVelocity.magnitude >= soundMagnitude)
        {
            audio.PlayOneShot(cardSoundClip);
        }
        knockCooldown = originalKnockCooldown;
    }

    void Start()
    {
        originalKnockCooldown = knockCooldown;
    }

    void FixedUpdate()
    {
        if (knockCooldown >= 0)
        {
            knockCooldown -= Time.deltaTime;
        }
    }
}
