using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 150f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private Animator anim;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            anim.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            anim.SetBool("run", true);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
        if (transform.hasChanged)
        {
            if(isGrounded)
            {
                anim.SetBool("run", true);
            } else
            {
                anim.SetBool("run", false);
            }
            transform.hasChanged = false;
        } else
        {
            anim.SetBool("run", false);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
        anim.SetBool("isGrounded", isGrounded);
    }

    void OnCollisionExit(Collision collision)
    {
        
        IsGroundedUpate(collision, false);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
        }
    }
}
