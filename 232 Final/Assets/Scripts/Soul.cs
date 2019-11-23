using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public static int souls;
    public ParticleSystem part;
    void OnTriggerEnter(Collider other)
    {
        if(true||other.tag == "Player")
        {
            Debug.Log("*************");
            souls++;
            part.Play();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        }
    }
    
}
