using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassCollisionSFX : MonoBehaviour
{
    public AudioSource audio;
    public double loudSoundMagnitude = 2.5, minSoundMagnitude = 0.25;
    public AudioClip knock1, knock2, knock3, knock4, knock5, tap1, tap2, tap3, tap4, tap5;
    public float knockCooldown = 0.15f;
    float originalKnockCooldown;

    private void OnCollisionEnter(Collision collision)
    {
        if (knockCooldown <= 0 && collision.relativeVelocity.magnitude >= minSoundMagnitude)
        {
            switch (Random.Range(1, 6))
            {
                case 1:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock1 : tap1);
                    break;
                case 2:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock2 : tap2);
                    break;
                case 3:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock3 : tap3);
                    break;
                case 4:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock4 : tap4);
                    break;
                case 5:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock5 : tap5);
                    break;
                default://should never reach here but whatever
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock5 : tap5);
                    break;
            }
        }
        knockCooldown = originalKnockCooldown;
    }

    void Start()
    {
        originalKnockCooldown = knockCooldown;
    }

    void FixedUpdate()
    {
        if(knockCooldown >= 0)
        {
            knockCooldown -= Time.deltaTime;
        }
    }
}
