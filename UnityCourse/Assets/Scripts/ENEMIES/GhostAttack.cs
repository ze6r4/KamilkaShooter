using enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyspace
{
    public class GhostAttack : MonoBehaviour
    {
        public bool attacking;
        private CharacterStateBase stateMachine;
        [SerializeField] private Cooldown _shootCooldown;
        [SerializeField] private float coolDown = 2f;
        private void Start()
        {
            stateMachine = GetComponent<CharacterStateBase>();
            _shootCooldown.cooldownTime = coolDown;
        }
        public void Attack()
        {
            if (_shootCooldown.canDoAction)
            {
                attacking = true;
                stateMachine.animator.SetBool("Attack", true);
                stateMachine.player.GetDamage(stateMachine.damage);     
                _shootCooldown.StartTimer();
            } else
            {
                attacking = false;
                stateMachine.animator.SetBool("Attack", false);
            }
        }
        public void Stop()
        {
            attacking =false;
            stateMachine.animator.SetBool("Attack", false);
        }
    }
}
