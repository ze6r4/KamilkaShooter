using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 150f;
    public float jumpForce = 5f;
    public float smoothBlend = 0.1f;

    private Rigidbody rb;
    private Animator anim;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            anim.SetFloat("Blend", Input.GetAxis("Vertical"), smoothBlend, Time.deltaTime);
        }
       

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("Blend", smoothBlend);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("Blend",smoothBlend);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
        }
    }
}
