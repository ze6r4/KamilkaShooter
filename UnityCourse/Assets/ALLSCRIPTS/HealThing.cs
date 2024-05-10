using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealThing : MonoBehaviour
{
    [SerializeField] public float heal;
    private void OnCollisionEnter(Collision collision)
    {
        Attack playerHp = collision.gameObject.GetComponent<Attack>();
        playerHp.Heal(heal);
        Destroy(gameObject);
    }
}
