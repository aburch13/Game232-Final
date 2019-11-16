using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSwipe : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D hit;
    public BoxCollider2D foot;
    private bool grounded, attacking;

    private Touch touch;
    private float time = 0;

    private Vector2 beginTouchPosition, endTouchPosition;
    void Update()
    {
        if (foot.isTrigger && body.velocity.y < 0 && foot.OverlapCollider(new ContactFilter2D(), new Collider2D[5]) == 0)
        {
            foot.isTrigger = false;
        }
        if(attacking)
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
                        grounded = false;
                        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 16);
                    }
                    if (!attacking && (endTouchPosition.y < beginTouchPosition.y) && transform.position.y > -3.5f)
                    {
                        grounded = false;
                        foot.isTrigger = true;
                        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -50);
                    }
                    Debug.Log("swiping");
                    
                    break;
            }
        }
    }
}
