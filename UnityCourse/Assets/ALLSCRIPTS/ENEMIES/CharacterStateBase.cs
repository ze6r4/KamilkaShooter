using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace enemyspace
{

    public class CharacterStateBase : MonoBehaviour
    {
        public List<Transform> targets;

        public EnemySettings settings;
        public Cooldown shootCooldown;

        public Scrollbar scroll;

        public Attack player;
        public Transform goal;
        public NavMeshAgent agent { get; private set; }
        public Animator animator;

        private float radiusToAttack;
        private float radiusToGetDamage;
        public float damage { get; private set; }
        private bool findGoal = false;

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

            radiusToAttack = settings.radiusToAttack;
            radiusToGetDamage = settings.radiusToGetDamage;
            damage = settings.damage;

            SetUpColor();

        }
        private void Start()
        {
            player = goal.gameObject.GetComponent<Attack>();
        }
        private void SetUpColor()
        {
            var s = GetComponentInChildren<SkinnedMeshRenderer>();
            Material thaIneeded = s.materials[0];
            thaIneeded.color = settings.color;
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
                 hp.GetDamage(player.weapon.attack);
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

