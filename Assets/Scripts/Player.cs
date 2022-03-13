using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    BoxCollider2D myBoxCollider2D;
    PolygonCollider2D myPlayersFeet;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myPlayersFeet = GetComponent<PolygonCollider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    private void Jump()
    {
        if(!myPlayersFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        bool isJumping = CrossPlatformInputManager.GetButtonDown("Jump");

        if(isJumping)
        {
            Vector2 jumpVelocity = new Vector2(myRigidbody2D.velocity.x, jumpSpeed);
            myRigidbody2D.velocity = jumpVelocity;
        }
        

    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;

        FlipSprite();

        ChangingToRunningState();

    }

    private void ChangingToRunningState()
    {
        bool runningHorizontaly = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", runningHorizontaly);
    }

    private void FlipSprite()
    {
        bool runningHorizontaly = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if(runningHorizontaly)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }

}
