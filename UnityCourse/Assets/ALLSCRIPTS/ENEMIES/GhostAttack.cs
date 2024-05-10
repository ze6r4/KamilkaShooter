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

        private EnemySettings settings;
        private void Start()
        {
            stateMachine = GetComponent<CharacterStateBase>();
            settings = stateMachine.settings;
            stateMachine.shootCooldown.cooldownTime = settings.coolDown;
        }
        public void Attack()
        {
            if (stateMachine.shootCooldown.canDoAction)
            {
                attacking = true;
                stateMachine.animator.SetBool("Attack", true);
                stateMachine.player.GetDamage(stateMachine.damage);
                stateMachine.shootCooldown.StartTimer();
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
