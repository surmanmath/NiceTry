using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaracterController : MonoBehaviour
{

    private bool facingRight = true;

    // Rigidity contains dunctions to apply physical movement
    public Rigidbody2D Rigidbody2D = null;

    //Velocity
    private Vector3 velocity = Vector3.zero;
    private float speed = 5f;

    // Move Damp
    [Range(0,0.3f)]
    public float moveDampFactor = 0.0f;

    //Input
    [Range(-1.0f,1.0f)]
    public float horizontalInput = 0f;

    //jump
    public bool jumpInput = false;

    public float jumpforce = 400f;

    // Update is called once per frame
    void Update()
    {   
        //input horizontal input
        this.horizontalInput = Input.GetAxisRaw("Horizontal");

        //input for jumping
        this.jumpInput = Input.GetKeyDown(KeyCode.UpArrow);
        if(this.jumpInput == true && this.isGrounded == true) {
            this.Rigidbody2D.AddForce(new Vector2(0f,jumpforce));
        }

        this.HandleFlip();
    }

    void FixedUpdate() {
        //Checked if growned
        this.UpdateGroundedStatus();

        //Handdle horizontal movement
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(this.horizontalInput * speed, this.Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            this.Rigidbody2D.velocity = Vector3.SmoothDamp(this.Rigidbody2D.velocity, targetVelocity, ref velocity, this.moveDampFactor);
        }    
    }

    private void HandleFlip() {   
        if (this.horizontalInput > 0 && facingRight == !true)
        {
            Flip();
        }
        else if (this.horizontalInput < 0 && facingRight == true)
        {
            Flip();
        }
    }

    private void Flip() {
        facingRight = !facingRight;

        Vector3 invertedScale = transform.localScale;
        invertedScale.x *= -1;

        transform.localScale = invertedScale;
    }

    [Header("physics")]
    public Transform groundChecker = null;
    public bool isGrounded = false;
    public LayerMask groundCheckLayerMask;

    public void UpdateGroundedStatus() {
        this.isGrounded = false;

        if (this.groundChecker != null) {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.groundChecker.transform.position, 0.4f, this.groundCheckLayerMask);
            if (colliders != null && colliders.Length > 0) {
                for (int i =0; i < colliders.Length; i++){
                    if (colliders[i].gameObject != this.gameObject) {
                        this.isGrounded = true;
                    }
                }
            }
        }
    }

}
