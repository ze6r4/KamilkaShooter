using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Zoom : MonoBehaviour
{
    public GameObject moveText;
    [SerializeField] private float ScrollSpeed = 10;

    [SerializeField] private float verticalSpeed = 200f;
    [SerializeField] private float horizontalSpeed = 100f;
    [SerializeField] private float minRotationY = -50f;
    [SerializeField] private float maxRotationY = 90f;

    private Camera camera1;

    public Transform playerRotation;
    private Vector3 lastPosition;
    public bool isMoving;

    private Vector3 currentRotation;
    float xRotation;
    float yRotation;
    private float distanceFromTarget = 3.0f;
    private Vector3 smoothVelocity = Vector3.zero;

    Vector3 deafultposition;
    Vector3 deafultrotation;
    void Start()
    {
        camera1 = Camera.main;
        xRotation = camera1.transform.rotation.x;
        yRotation = camera1.transform.rotation.y;
        lastPosition = playerRotation.position;
        isMoving = false;
        deafultposition = transform.localPosition;
        deafultrotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !checkMoving())
        {
            float mouseX = Input.GetAxis("Mouse X") * verticalSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * horizontalSpeed * Time.deltaTime;

            yRotation -= mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, minRotationY, maxRotationY);

            Vector3 nextRotation = new Vector3(xRotation, yRotation);
            currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, Time.deltaTime);
            transform.localEulerAngles = currentRotation;
            transform.position = playerRotation.position - transform.forward * distanceFromTarget;
            moveText.SetActive(false);
        }
        else if (checkMoving())
        {
            transform.localPosition = deafultposition;
            transform.localEulerAngles = deafultrotation;
        }
        
        camera1.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        
    }
    private bool checkMoving()
    {
        isMoving = playerRotation.position != lastPosition;
        lastPosition = playerRotation.position;
        return isMoving;
    }
}
