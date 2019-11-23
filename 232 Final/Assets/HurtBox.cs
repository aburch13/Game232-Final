using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public ParticleSystem soul;
    public ParticleSystem death;
    private bool die = false;
    private float deathtimer = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ASDFASDFASDF00");
        if(other.tag == "Soul")
        {
            soul.Play();
            Destroy(other);
        }
        else if(other.tag == "Enemy")
        {
            die = true;
            death.Play();
        }
    }
    private void Update()
    {
        if(die)
        {
            deathtimer += Time.deltaTime;
        }
        if (deathtimer >= 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
