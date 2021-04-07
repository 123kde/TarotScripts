using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassCollisionSFX : MonoBehaviour
{
    public AudioSource audio;
    public int loudSoundMagnitude = 3;
    public AudioClip knock1, knock2, knock3, knock4, knock5, tap1, tap2, tap3, tap4, tap5;
    float knockCooldown = 0.15f;

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision);
        //print(collision.relativeVelocity.magnitude);
        int random = Random.Range(1, 6);
        
        if(collision.relativeVelocity.magnitude < 0.5)
        {
            return;
        }

        if(collision.relativeVelocity.magnitude >= 3 && knockCooldown <= 0)
        {
            switch (random)
            {
                case 1:
                    audio.PlayOneShot(knock1);
                    print(random + "knock1");
                    knockCooldown = 0.15f;
                    break;
                case 2:
                    audio.PlayOneShot(knock2);
                    print(random + "knock2");
                    knockCooldown = 0.15f;
                    break;
                case 3:
                    audio.PlayOneShot(knock3);
                    print(random + "knock3");
                    knockCooldown = 0.15f;
                    break;
                case 4:
                    audio.PlayOneShot(knock4);
                    print(random + "knock4");
                    knockCooldown = 0.15f;
                    break;
                case 5:
                    audio.PlayOneShot(knock5);
                    print(random + "knock5");
                    knockCooldown = 0.15f;
                    break;
                default://should never reach here but whatever
                    audio.PlayOneShot(knock5);
                    knockCooldown = 0.15f;
                    print(random + "defaultknock");
                    break;

            }
        }
        else if(knockCooldown <= 0)
        {
            switch (random)
            {
                case 1:
                    audio.PlayOneShot(tap1);
                    print(random + "tap1");
                    knockCooldown = 0.15f;
                    break;
                case 2:
                    audio.PlayOneShot(tap2);
                    print(random + "tap2");
                    knockCooldown = 0.15f;
                    break;
                case 3:
                    audio.PlayOneShot(tap3);
                    print(random + "tap3");
                    knockCooldown = 0.15f;
                    break;
                case 4:
                    audio.PlayOneShot(tap4);
                    print(random + "tap4");
                    knockCooldown = 0.15f;
                    break;
                case 5:
                    audio.PlayOneShot(tap5);
                    print(random + "tap5");
                    knockCooldown = 0.15f;
                    break;
                default://should never reach here but whatever
                    audio.PlayOneShot(tap5);
                    print(random + "defaulttap");
                    knockCooldown = 0.15f;
                    break;

            }
        }


    }

    private void FixedUpdate()
    {
        knockCooldown -= Time.deltaTime;
        //print(knockCooldown + "is knock cooldown");
    }

}
