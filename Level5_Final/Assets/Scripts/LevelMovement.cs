using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    private static bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    public static void Stop()
    {
        stop = true;
    }

}
