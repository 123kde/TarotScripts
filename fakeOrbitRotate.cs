using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeOrbitRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.up
        transform.Rotate( new Vector3(0, (float)0.1, 0) * Time.deltaTime/*, Space.World*/);
        //transform.Rotate(new Vector3((float)-0.001, 0, 0));
    }
}
