using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public AnimatorControllerParameter cupola;
    public Animator characterAnimator;
    public AudioSource button, shield;
    public AudioClip buttonClick, motors;
    bool pushed = false;
    bool down = false;

    public void press()
    {
        if (!down)
        {
            button.PlayOneShot(buttonClick);
            down = true;
        }
        if (!pushed)
        {
            pushed = true;
            characterAnimator.SetBool("buttonPushed", true);
            Invoke("playMotorSound", 4.5f);
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (!pushed)
        {
            pushed = true;
            characterAnimator.SetBool("buttonPushed", true);

            button.PlayOneShot(buttonClick);

            Invoke("playMotorSound", 20);
        }
    }
    */

    private void playMotorSound()
    {
        shield.PlayOneShot(motors);
        Invoke("stopMotorSound", 4);
    }

    private void stopMotorSound()
    {
        shield.Stop();
    }

    public void setDownFalse()
    {
        down = false;
    }
}
