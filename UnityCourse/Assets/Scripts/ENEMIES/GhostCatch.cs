using enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyspace
{
    public class GhostCatch : MonoBehaviour
    {
        private CharacterStateBase stateMachine;
        private void Start()
        {
            stateMachine = GetComponent<CharacterStateBase>();
        }
        public void Catch()
        {
            stateMachine.agent.destination = stateMachine.goal.position;
        }
    }
}
