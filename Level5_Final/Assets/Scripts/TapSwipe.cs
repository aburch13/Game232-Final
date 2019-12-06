using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSwipe : MonoBehaviour
{
    public Rigidbody body;
    public BoxCollider hit;
    public BoxCollider foot;
    private bool grounded = true;
    public static bool attacking = false;

    private Touch touch;
    private float time = 0;

    private Vector2 beginTouchPosition, endTouchPosition;
    void Update()
    {
        grounded = System.Math.Abs(body.velocity.y) < 0.1;
        if (!grounded)
        {
            body.AddForce(new Vector3(0, -80, 0), ForceMode.Acceleration);
        }
        if (foot.isTrigger && body.velocity.y < 0)
        {
            foot.isTrigger = false;
        }
        if (!attacking && grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            foot.isTrigger = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, 20);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hit.enabled = true;
            attacking = true;
            Debug.Log("tapping");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foot.isTrigger = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, -20);
        }
        if (attacking)
        {
            time += Time.deltaTime;
            if (time > .5)
            {
                attacking = false;
                time = 0;
            }
        }
        else if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    beginTouchPosition = touch.position;
                    break;

                //case TouchPhase.Moved:

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;

                    //tap
                    if (beginTouchPosition == endTouchPosition)
                    {
                        hit.enabled = true;
                        attacking = true;
                        Debug.Log("tapping");
                    }
                    //swipe
                    if (!attacking && grounded && beginTouchPosition != endTouchPosition)
                    {
                        foot.isTrigger = true;
                        gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, 20);
                    }
                    if (!attacking && (endTouchPosition.y < beginTouchPosition.y) && transform.position.y > -3.5f)
                    {
                        foot.isTrigger = true;
                        gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, -20);
                    }
                    Debug.Log("swiping");
                    
                    break;
            }
        }
    }
    public void ground()
    {
        grounded = true;

    }
    public void fall()
    {
        grounded = false;
    }
}
