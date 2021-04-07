using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public AnimatorControllerParameter cupola;
    public Animator characterAnimator;

    private void OnCollisionEnter(Collision collision)
    {
        characterAnimator.SetBool("buttonPushed", true);
        //code shield opening and button click sounds here
    }
}
