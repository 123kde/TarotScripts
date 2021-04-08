using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScene : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip daBaby;

    public void LetsGo()
    {
        audio.PlayOneShot(daBaby);
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
