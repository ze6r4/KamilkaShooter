using enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemyspace
{
    public class GhostIdle : MonoBehaviour
    {
        private CharacterStateBase stateMachine;
        private float smoothBlend;
        List<Transform> targets;
        int i;
        private void Start()
        {
            stateMachine = GetComponent<CharacterStateBase>();
            smoothBlend = stateMachine.settings.smoothBlend;
            targets = stateMachine.targets;
        }
        void TargetUpdate()
        {
            i = Random.Range(0, targets.Count);
        }
        public void Move()
        {
            if(stateMachine.agent.transform.position == stateMachine.agent.pathEndPosition)
            {
                TargetUpdate();
            }
            stateMachine.agent.SetDestination(targets[i].transform.position); 
            stateMachine.animator.SetFloat("Blend", Input.GetAxis("Vertical"), smoothBlend, Time.deltaTime);
        }
       
    }
}
