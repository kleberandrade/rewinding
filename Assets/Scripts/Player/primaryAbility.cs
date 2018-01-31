using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(menuName = "Abilities/PrimaryAbility")]
public class primaryAbility : Ability
{
    [SerializeField] Rigidbody2D    m_playerBody;
    [SerializeField] float          m_forceJump = 200f;
    [SerializeField] float          m_groundDistance = 0.2f;
    [SerializeField] bool           m_isJump = false;
    [SerializeField] bool           m_doubleJump = false;
    [SerializeField] bool           m_isGrounded = false;
    [SerializeField] Transform      m_groundCheck;
    [SerializeField] LayerMask m_whatIsGround;
    
    private          basicAbility   m_bAbility;

    public override void Initialize(GameObject obj)
    {
        m_isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, 0.02f, m_whatIsGround);

        m_bAbility = obj.GetComponent<basicAbility>();

        m_bAbility.Initialize();
        m_bAbility.m_groundCheck = m_groundCheck;
        m_bAbility.m_playerBody = m_playerBody;
        m_bAbility.m_forceJump = m_forceJump;
        m_bAbility.m_groundDistance = m_groundDistance;
        m_bAbility.m_isJump = m_isJump;
        m_bAbility.m_doubleJump = m_doubleJump;
        m_bAbility.m_isGrounded = m_isGrounded;
    }

    public override void TriggerAbility()
    {
        m_bAbility.Jump();
    }
}