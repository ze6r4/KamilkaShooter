using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace enemyspace
{

    public class CharacterStateBase : MonoBehaviour
    {
        [field: SerializeField] public List<Transform> targets;
        [field: SerializeField] public float radiusToGetDamage = 3f;
        [field: SerializeField] public float radiusToAttack = 1f;
        [field: SerializeField] public float damage = 10f;

        public Scrollbar scroll;

        [SerializeField] private bool findGoal = false;
        public Attack player;

        public Transform goal;
        public NavMeshAgent agent;
        public Animator animator;

         GhostIdle idle;
         GhostCatch catcher;
         GhostAttack attack;
         GhostHealth hp;

        private void Awake()
        {
            idle = GetComponent<GhostIdle>();
            catcher = GetComponent<GhostCatch>();
            attack = GetComponent<GhostAttack>();
            hp = GetComponent<GhostHealth>();

            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            player = goal.gameObject.GetComponent<Attack>();
        }
        private void Update()
        {
            if (hp.isDead) return;

            if (!findGoal && targets.Count > 0)
            {
                idle.Move();
            }
            else if (findGoal)
            {
                catcher.Catch();
                Battle();
            }
        }
        private void Battle()
        {
            if(inRange(transform.position, radiusToAttack))
            {
                attack.Attack();
            }
            else if (!inRange(transform.position, radiusToAttack))
            {
                attack.Stop();
            }
            if (inRange(transform.position, radiusToGetDamage) && player.attacking)
            {
                 hp.GetDamage(player.attack);
                
            }
            
        }
       
        public bool inRange(Vector3 position, float radius)
        {
            float distance = Vector3.Distance(position, goal.position);
            return distance <= radius;
        }
        private void OnTriggerEnter(Collider other)
        {
            findGoal = true;
        }
        private void OnTriggerExit(Collider other)
        {
            findGoal = false;
        }
    }
}

