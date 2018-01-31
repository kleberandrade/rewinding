using UnityEngine;
using System.Collections;

public class basicAbility : MonoBehaviour
{
    //Jump Attributes
    [Header("Jump")]
    public Rigidbody2D    m_playerBody;
    public float          m_forceJump = 200f;
    public float          m_groundDistance = 0.2f;
    public bool           m_isJump = true;
    public bool           m_doubleJump = false;
    public bool           m_isGrounded = false;
    public Transform      m_groundCheck;
    public LayerMask      m_whatIsGround;
    
    public void Initialize()
    {
        m_playerBody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        m_isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, 0.2f, m_whatIsGround);

        Debug.Log(m_isGrounded);
        Debug.Log(m_whatIsGround);
        Debug.Log(m_groundCheck);

        //Activate jump
        if (m_isGrounded)
        {
            Debug.Log("Entrou");

            m_doubleJump = true;
        }

        if (m_isGrounded && m_isJump)
        {
            Debug.Log("Entrou 2");

            physicJump();
        }
        else if (m_doubleJump && m_isJump)
        {
            physicJump();
            m_doubleJump = false;
        }
    }

    void physicJump()
    {
        Vector2 velocity = m_playerBody.velocity;
        velocity.y = 0;
        m_playerBody.velocity = velocity;
        m_playerBody.AddForce(new Vector2(0, 1f * m_forceJump));
    }
}