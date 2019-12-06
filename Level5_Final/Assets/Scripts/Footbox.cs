using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footbox : MonoBehaviour
{
    public TapSwipe controller;

    public void OnCollisionEnter(Collision collision)
    {
        
            Debug.Log("GROUND");
            controller.ground();
        
    }
    public void OnCollisionExit(Collision collision)
    {
        controller.fall();
    }
}
