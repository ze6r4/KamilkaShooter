using enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace enemyspace
{
    public class GhostHealth : MonoBehaviour
    {
        private CharacterStateBase stateMachine;
        [SerializeField]public float CurrentHealth { get; private set; }
        private int maxHealth;
        public bool isDead = false;
        private Scrollbar scroll;
        private void Start()
        {
            stateMachine = GetComponent<CharacterStateBase>();
            maxHealth = stateMachine.settings.maxHealth;
            CurrentHealth = maxHealth;
            scroll = stateMachine.scroll;
        }
        public void GetDamage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
            scroll.size = CurrentHealth / maxHealth;
            var color = scroll.colors;
            if (scroll.size <= 0.2f)
            {

                color.normalColor = UnityEngine.Color.red;
            }
            else if (scroll.size <= 0.6f)
            {
                color.normalColor = UnityEngine.Color.yellow;
            }
            else
            {
                color.normalColor = UnityEngine.Color.green;

            }
            scroll.colors = color;

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
        void Die()
        {
            stateMachine.animator.SetTrigger("Die");
            isDead = true;
            Destroy(gameObject);
        }
    }
}
