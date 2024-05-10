using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Weapon Settings")]
public class WeaponSettings : ScriptableObject

{
    [SerializeField] private int _attack = 10;
    public int attack => this._attack;
    [SerializeField] private float _coolDown = 1f;
    public float coolDown => this._coolDown;

    [Header("Внешний вид")]
    [SerializeField] private Material _material;
    public Material material => this._material;

    [SerializeField] private Color _color;
    public Color color => this._color;
}
