using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : Enemy
{
    public static int bossHP = 20;
    public new void die()
    {
        part.Play();
        GetComponentInChildren<SpriteRenderer>().color = new Color(0,0,0,0);
        bossHP--;
        Debug.Log(bossHP);
    }
}
