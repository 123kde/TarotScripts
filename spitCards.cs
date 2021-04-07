using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitCards : MonoBehaviour
{
    public AudioSource audio;
    public double loudSoundMagnitude = 2.5, minSoundMagnitude = 0.25, minImpact = 5;
    public AudioClip knock1, knock2, knock3, tap1, tap2, tap3;
    public float knockCooldown = 0.15f;
    public GameObject Temperance, Star, Magician, Strength, Fool, anchor;
    bool spat = false;

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.relativeVelocity.magnitude >= minSoundMagnitude) && knockCooldown <= 0)
        {
            switch (Random.Range(1, 4))
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
                default://should never reach here but whatever
                    audio.PlayOneShot(collision.relativeVelocity.magnitude >= loudSoundMagnitude ? knock3 : tap3);
                    break;
            }

            if(!spat && collision.relativeVelocity.magnitude >= minImpact)
            {
                spat = true;
                GameObject current = null;
                Rigidbody rba = anchor.GetComponent<Rigidbody>();

                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            current = Fool;
                            break;
                        case 1:
                            current = Magician;
                            break;
                        case 2:
                            current = Strength;
                            break;
                        case 3:
                            current = Temperance;
                            break;
                        case 4:
                            current = Star;
                            break;
                        default:
                            Debug.LogException(new System.Exception("should not be here, card switch statement failed"));
                            break;
                    }

                    current.SetActive(true);
                    Rigidbody rb = current.GetComponent<Rigidbody>();
                    rb.velocity = (rba.position - rb.position / (Time.fixedDeltaTime * 30)); // * 30 slows it down, without it is warp speed lol
                }
                //put audio of cards shuffling out here
            }
        }
        knockCooldown = 0.15f;
    }

    private void FixedUpdate()
    {
        knockCooldown -= Time.deltaTime;
    }
}

