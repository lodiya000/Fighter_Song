using UnityEngine;
using UnityEngine.AI;


namespace Lodiya
{
    public class Enemy : Character
    {
        #region 狀態
        public EnemyIdle enemyIdle { get; private set; }
        public EnemyWander enemyWander { get; private set; }
        public EnemyTrack enemyTrack { get; private set; }
        public EnemyAttack enemyAttack { get; private set; }
        public EnemyDead enemyDead { get; private set; }
        #endregion

        [field: SerializeField, Tooltip("待機時間範圍")]
        public Vector2 idleRange { get; private set; } = new Vector2(1f, 3f);
        [field: SerializeField, Tooltip("遊走時間範圍")]
        public Vector2 wanderRange { get; private set; } = new Vector2(1f, 5f);
        [SerializeField, Tooltip("是否顯示遊走範圍")]
        public bool showWanderGizmos;
        [field: SerializeField, Range(0f, 10)]
        public float wanderRadius { get; private set; } = 5;
        [SerializeField, Tooltip("是否顯示追蹤範圍")]
        public bool showTrackGizmos;
        [field: SerializeField, Range(0f, 10)]
        public float trackRadius { get; private set; } = 5;
        [field: SerializeField, Range(0f, 10)]
        public float attackDistance { get; private set; } = 1.7f;
        [field: SerializeField, Range(0f, 10)]
        public float attackCD { get; private set; } = 2.5f;


        public float trackSpeed { get; private set; } = 3.5f;

        [field: SerializeField]
        public Vector3 originalPosition { get; private set; }

        public NavMeshAgent agent { get; private set; }

        public Transform player {  get; private set; }

        public Collider col;

        protected override void Awake()
        {
            base.Awake();

            agent = GetComponent<NavMeshAgent>();
            player = GameObject.Find(Player.m_name).transform;
            agent.speed = walkSpeed;
            col = GetComponent<Collider>();

            #region 實例化
            enemyIdle = new EnemyIdle($"{name}待機", stateMachine, this);
            enemyWander = new EnemyWander($"{name}遊走", stateMachine, this);
            enemyTrack = new EnemyTrack($"{name}追蹤", stateMachine, this);
            enemyAttack = new EnemyAttack($"{name}攻擊", stateMachine, this);
            enemyDead = new EnemyDead($"{name}死亡", stateMachine, this);

            stateMachine.Initialize(enemyIdle);
            #endregion
        }

        private void OnDrawGizmosSelected()
        {
            if (showWanderGizmos)
            {
                Gizmos.color = new Color(0.7f, 1f, 0.7f, 0.5f);
                Gizmos.DrawSphere(originalPosition, wanderRadius);
            }

            if (showTrackGizmos)
            {
                Gizmos.color = new Color(1f, 0.8f, 0.3f, 0.3f);
                Gizmos.DrawSphere(originalPosition, trackRadius);
            }

            //Gizmos.color = new Color(0.5f, 0.9f, 1f, 1f);
            //Gizmos.DrawSphere(RandomPosition(originalPosition, wanderRadius),0.5f);

        }

        [ContextMenu("獲得初始座標")]
        private void GetOriginalPosition()
        {
            originalPosition = transform.position;
        }

        public Vector3 RandomPosition(Vector3 center, float radius)
        {
            Vector3 result = center + Random.insideUnitSphere * radius;
            result.y = 0;

            if(NavMesh.SamplePosition(result, out NavMeshHit hit, radius, NavMesh.AllAreas))
                result = hit.position;
            return result;
        }

        public bool IsPlayerInTrackArea()
        {
            return Physics.OverlapSphere(originalPosition, trackRadius, Player.m_layer).Length > 0;
        }

        protected override void Update()
        {
            base.Update();

        }

        protected override void Dead()
        {
            base.Dead();
            stateMachine.SwitchState(enemyDead);
        }
    }
}