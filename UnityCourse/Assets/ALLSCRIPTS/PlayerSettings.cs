using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player Settings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _HP = 100f;
    public float HP => this._HP;
    [SerializeField] private float _speed = 5f;
    public float speed => this._speed;
    [SerializeField] private float _rotationSpeed = 150f;
    public float rotationSpeed => this._rotationSpeed;
    [SerializeField] private float _jumpForce = 5f;
    public float jumpForce => this._jumpForce;
    [SerializeField] private float _smoothBlend = 0.1f;
    public float smoothBlend => this._smoothBlend;
}
