using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleScript : MonoBehaviour
{
    public AudioSource appleSound;
    public AudioClip appleCrunch, appleImpact;
    public double soundMagnitude = 0.75;
    public float knockCooldown = 0.15f;
    float originalKnockCooldown;
    bool held = false;

    public void setHeldTrue()
    {
        held = true;
    }

    public void setHeldFalse()
    {
        held = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (held && collision.gameObject.name == "HeadCollider")
        {
            appleSound.PlayOneShot(appleCrunch);
            Destroy(this.gameObject);
        }
        else if (knockCooldown <= 0 && collision.relativeVelocity.magnitude >= soundMagnitude)
        {
            appleSound.PlayOneShot(appleImpact);
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
