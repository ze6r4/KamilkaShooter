using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public float HP = 100f;
    public float speed = 5f;
    public float rotationSpeed = 150f;
    public float jumpForce = 5f;
    public float smoothBlend = 0.1f;
}
