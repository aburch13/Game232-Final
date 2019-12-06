using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfDemoPlayerControllerNew : MonoBehaviour
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    public float m_JumpPower = 1f;
    public float speed = 12f;


    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Rigidbody m_Rigidbody;

    private CapsuleCollider col;

    bool grounded = true;

    bool grounded2 = true;

    void Awake()

    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()

    {

        float move = Input.GetAxis("Horizontal");

        float moveVertical = m_JumpPower;


        animator.SetFloat("speed", Mathf.Abs(move));

        GetComponent<Rigidbody>().velocity = new Vector3(move * speed, GetComponent<Rigidbody>().velocity.y);


        if (m_Rigidbody.velocity.y > 0)
        {
            animator.SetBool("grounded2", false);
            Debug.Log("Hey grounded2");
        }

        else
        {
            animator.SetBool("grounded2", true);
        }

        if (Input.GetButtonDown("Jump"))

        {

            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);

            animator.SetFloat("moveVertical", Mathf.Abs(m_JumpPower));

            animator.SetBool("grounded", false);

        }

        else if (Input.GetButtonUp("Jump"))
        {

            if (moveVertical > 0.1f)
            {
                moveVertical = moveVertical * 1.5f;
                animator.SetBool("grounded", true);
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move > 0.0f) : (move < 0.0f)); if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
}