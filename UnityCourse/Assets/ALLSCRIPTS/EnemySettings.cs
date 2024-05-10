using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Settings")]
public class EnemySettings : ScriptableObject
{
    [field: SerializeField] private int _maxHealth = 50;
    public int maxHealth => _maxHealth;

    [field: SerializeField] private float _radiusToGetDamage = 3f;
    public float radiusToGetDamage => _radiusToGetDamage;

    [Header("жбер :333")]
    [field: SerializeField] private Color _color;
    public Color color => _color;
    [Header("Walk")]
    [SerializeField] private float _smoothBlend = 0.1f;
    public float smoothBlend => _smoothBlend;
    [Header("Attack")]

    [SerializeField] private float _coolDown = 2f;
    public float coolDown => _coolDown;
    [field: SerializeField] private float _radiusToAttack = 1f;
    public float radiusToAttack => _radiusToAttack;
    [field: SerializeField] private float _damage = 10f;
    public float damage => _damage;
}
