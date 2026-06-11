using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //public variables
    public float walkSpeed = 3f;
    public float jumpheight = 3f;
    public float cameraOffsetX = 8f;
    public float cameraOffsetY = 2f;
    public float smoothTime = 0.25f;
    public Vector3 cameraVelocity = Vector3.zero;

    public  GameObject myCamera;

    //private variables
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private float capsuleHalf;
    private Animator animator;

    //Bools for the animation
    private bool isGrounded = true;
    private bool isMoving = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        capsuleHalf = capsuleCollider.height / 2;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        //Movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, Input.GetAxis("Horizontal"))), 0.15F);

            transform.position += (new Vector3(0, 0, Input.GetAxis("Horizontal")) *walkSpeed*Time.deltaTime);
            isMoving = true;
            animator.SetBool("isMoving", true);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", false);
        }
        //Jumping
        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(0,jumpheight,0);

        }

        //Camera
        myCamera.transform.position = Vector3.SmoothDamp(myCamera.transform.position,new Vector3(transform.position.x+cameraOffsetX,transform.position.y+cameraOffsetY,transform.position.z),ref cameraVelocity,smoothTime);
    
    }
    void CheckGround()
    {
        Physics.Raycast(capsuleCollider.bounds.center, Vector3.down, out var hit);
        //Stop player from jumping on colliders that aren't for them
        if (!hit.collider.CompareTag("UnJumpable"))
        {
            if (hit.distance < (capsuleHalf + 0.1f))
            {
                isGrounded = true;
                animator.SetBool("isGrounded", true);
            }
            else
            {
                isGrounded = false;
                animator.SetBool("isGrounded", false);
            }
        }
    }
}
