using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotPlayer : MonoBehaviour {

    [SerializeField]    Rigidbody2D         playerBody;

    //Jump Attributes
    [Header("Jump")]
    [SerializeField]    float               forceJump;
    [SerializeField]    float               groundDistance;
    [SerializeField]    bool                isJump = false;
    [SerializeField]    bool                doubleJump = false;
    [SerializeField]    bool                isGrounded = false;
    public              Transform           groundCheck;
    public              LayerMask           whatIsGround;

	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        isJump = Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

        //Activate jump
        if (isGrounded)
        {
            doubleJump = true;
        }

        if (isGrounded && isJump)
        {
            Jump();
        }
        else if (doubleJump && isJump)
        {
            Jump();
            doubleJump = false;
        }
    }

    //Jump function
    void Jump()
    {
        Vector2 velocity = playerBody.velocity;
        velocity.y = 0;
        playerBody.velocity = velocity;

        playerBody.AddForce(new Vector2(0, 1f * forceJump));
    }
}
