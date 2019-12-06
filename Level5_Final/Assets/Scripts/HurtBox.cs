using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public ParticleSystem soul;
    public ParticleSystem death;
    private bool die = false;
    private float deathtimer = 0;

    
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
    public void OnTriggerEnter(Collider other)
    {
        if (TapSwipe.attacking)
        {
            other.gameObject.GetComponentInParent<Disk>().die();
        }
        else if (other.tag == "Soul")
        {
            soul.Play();
            Destroy(other);
        }
        else if (other.tag == "Enemy")
        {
            die = true;
            LevelMovement.Stop();
            death.Play();
        }

    }
}
