using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solarPanelRotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3((float)-0.1, 0, 0) * Time.deltaTime/*, Space.World*/);
    }
}
