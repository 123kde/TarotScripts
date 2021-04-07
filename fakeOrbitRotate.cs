using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeOrbitRotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate( new Vector3(0, (float)0.1, 0) * Time.deltaTime/*, Space.World*/);
    }
}
