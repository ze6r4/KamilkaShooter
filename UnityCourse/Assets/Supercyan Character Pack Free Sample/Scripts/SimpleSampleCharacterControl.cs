using System.Collections.Generic;
using UnityEngine;

namespace Supercyan.FreeSample
{
    public class SimpleSampleCharacterControl : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed = 2;
        [SerializeField] private float m_turnSpeed = 20;
        [SerializeField] private float m_jumpForce = 1;

        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody m_rigidBody;

        private bool m_wasGrounded;
        private Vector3 m_currentDirection = Vector3.zero;
        private void Awake()
        { 
            m_animator = GetComponent<Animator>(); 
            m_rigidBody = GetComponent<Rigidbody>();       
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jumping();
                
            }
        }

        private void FixedUpdate()
        {
            m_animator.SetBool("Grounded", true);
            DirectUpdate();
        }

        private void DirectUpdate()
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            Transform camera = Camera.main.transform;
            
            Vector3 forward = camera.forward;
            Vector3 right = camera.right;
            forward.y = 0;
            right.y = 0;
            forward = forward.normalized;
            right = right.normalized;

            Vector3 verticalInput = v * forward;
            Vector3 horisontalInput = h * right;

            Vector3 cameraMovement = verticalInput + horisontalInput;
            this.transform.Translate(cameraMovement, Space.World);
            
            m_animator.SetFloat("MoveSpeed", 0.1f);
            
        }

        private void Jumping()
        {
            m_animator.SetBool("Grounded", false);
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.VelocityChange);
            
        }
    }
}
