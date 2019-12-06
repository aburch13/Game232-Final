using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem part;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Attack")
        {
            die();
        }
    }
    public void die()
    {
        part.Play();
        gameObject.SetActive(false);
    }
}
