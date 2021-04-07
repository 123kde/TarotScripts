using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassCollisionSFX : MonoBehaviour
{
    public AudioSource audio;
    public double loudSoundMagnitude = 2.5;
    public AudioClip knock1, knock2, knock3, knock4, knock5, tap1, tap2, tap3, tap4, tap5;
    float knockCooldown = 0.15f;

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision);
        //print(collision.relativeVelocity.magnitude);
        int random = Random.Range(1, 6);

        if (collision.relativeVelocity.magnitude < 0.5)
        {
            knockCooldown = 0.15f;
            return;
        }

        if (knockCooldown <= 0)
        {
            switch (random)
            {
                case 1:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock1 : tap1);
                    //print(random + "knock1");
                    break;
                case 2:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock2 : tap2);
                    //print(random + "knock2");
                    break;
                case 3:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock3 : tap3);
                    //print(random + "knock3");
                    break;
                case 4:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock4 : tap4);
                    //print(random + "knock4");
                    break;
                case 5:
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock5 : tap5);
                    //print(random + "knock5");
                    break;
                default://should never reach here but whatever
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock5 : tap5);
                    //print(random + "defaultknock");
                    break;

            }
        }

        knockCooldown = 0.15f;

        /*if(collision.relativeVelocity.magnitude >= 3 && knockCooldown <= 0)
        {
            switch (random)
            {
                case 1:
                    audio.PlayOneShot(knock1);
                    //print(random + "knock1");
                    break;
                case 2:
                    audio.PlayOneShot(knock2);
                    //print(random + "knock2");
                    break;
                case 3:
                    audio.PlayOneShot(knock3);
                    //print(random + "knock3");
                    break;
                case 4:
                    audio.PlayOneShot(knock4);
                    //print(random + "knock4");
                    break;
                case 5:
                    audio.PlayOneShot(knock5);
                    //print(random + "knock5");
                    break;
                default://should never reach here but whatever
                    audio.PlayOneShot(knock5);
                    //print(random + "defaultknock");
                    break;

            }
        }
        else if(knockCooldown <= 0)
        {
            switch (random)
            {
                case 1:
                    audio.PlayOneShot(tap1);
                    //print(random + "tap1");
                    break;
                case 2:
                    audio.PlayOneShot(tap2);
                    //print(random + "tap2");
                    break;
                case 3:
                    audio.PlayOneShot(tap3);
                    //print(random + "tap3");
                    break;
                case 4:
                    audio.PlayOneShot(tap4);
                    //print(random + "tap4");
                    break;
                case 5:
                    audio.PlayOneShot(tap5);
                    //print(random + "tap5");
                    break;
                default://should never reach here but whatever
                    audio.PlayOneShot(tap5);
                    //print(random + "defaulttap");
                    break;

            }
        }*/


    }

    private void FixedUpdate()
    {
        knockCooldown -= Time.deltaTime;
        //print(knockCooldown + "is knock cooldown");
    }

}
