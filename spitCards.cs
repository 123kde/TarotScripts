using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitCards : MonoBehaviour
{
    public AudioSource audio;
    public double loudSoundMagnitude = 2.5, minSoundMagnitude = 0.25, minImpact = 5;
    public AudioClip knock1, knock2, knock3, knock4, knock5, tap1, tap2, tap3, tap4, tap5;
    public float knockCooldown = 0.15f, cardCooldown = 0.075f;
    public GameObject Temperance, Star, Magician, Strength, Fool, anchor;
    bool spat = false;

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.relativeVelocity.magnitude >= minSoundMagnitude) && knockCooldown <= 0)
        {
            int random = Random.Range(1, 6);

            switch (random)
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

            if(!spat && collision.relativeVelocity.magnitude >= minImpact)
            {
                knockCooldown = 0.15f;
                float cardCooldownOriginal = cardCooldown;
                spat = true;
                GameObject current = Fool;

                for(int i = 0; i < 5; i++)
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
                    Rigidbody rba = anchor.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.velocity = (rba.position - rb.position /* - new Vector3(0f, 0.05f, 0.05f)) *// (Time.fixedDeltaTime * 10));

                    rb.isKinematic = false;
                    cardCooldown = cardCooldownOriginal;
                }
            }
        }
        knockCooldown = 0.15f;
    }

    private void FixedUpdate()
    {
        knockCooldown -= Time.deltaTime;

        if (spat && cardCooldown >= 0)
        {
            cardCooldown -= Time.deltaTime;
        }
    }
}

