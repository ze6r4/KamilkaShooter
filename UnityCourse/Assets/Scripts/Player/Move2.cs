using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move2 : MonoBehaviour
{
    float speed;
    float rotationSpeed;
    float jumpForce;
    float smoothBlend;
    private Rigidbody rb;
    private Animator anim;
    public bool isGrounded;

    void Start()
    {
        PlayerSettings set = (PlayerSettings)ScriptableObject.CreateInstance(typeof(PlayerSettings));
        speed = set.speed;
        rotationSpeed = set.rotationSpeed;
        jumpForce = set.jumpForce;
        smoothBlend = set.smoothBlend;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        float dirY = Input.GetAxis("Vertical");
        if (isGrounded)
        {
            anim.SetFloat("Blend", dirY, smoothBlend, Time.deltaTime);
        }
        transform.Translate(new Vector3(0, 0, dirY) * speed * Time.deltaTime);
       

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
    }
   

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
            anim.SetBool("isGrounded", value);
            anim.SetFloat("Blend", smoothBlend);
        }
    }
}
