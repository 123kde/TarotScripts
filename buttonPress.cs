using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{

    public AnimatorControllerParameter cupola;
    public Animator characterAnimator;


    private void OnCollisionEnter(Collision collision)
    {
        print("HIT");
        characterAnimator.SetBool("buttonPushed", true);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
