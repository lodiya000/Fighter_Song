using UnityEngine;

namespace Lodiya
{
    public class Player : Character
    {
        public const string m_name = "玩家";
        public static LayerMask m_layer = 1 << 7;

        [SerializeField, Range(5, 20), Tooltip("攝影機軟轉速度")]
        public float turnSpeed = 10;


        [Header("檢查資料")]
        [SerializeField, Range(-10, 10)]
        private float cheakGroundRadius = 3;
        [SerializeField, Range(-10, 10)]
        private float cheakGroundOffest;
        [SerializeField]
        private LayerMask layerCanJump;
        

        private Transform traCamera;

        #region 狀態機與狀態
        public PlayerIdle playerIdle { get; private set; }
        public PlayerWalk playerWalk { get; private set; }
        //public PlayerAttack playerAttack { get; private set; }
        public PlayerDead playerDead { get; private set; }
        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawSphere(
                transform.position + Vector3.up * cheakGroundOffest, cheakGroundRadius );
        }

        protected override void Awake()
        {
            base.Awake();

            #region 實例化
            playerIdle = new PlayerIdle($"{name}待機", stateMachine, this);
            playerWalk = new PlayerWalk($"{name}走路", stateMachine, this);
            //playerAttack = new PlayerAttack($"{name}攻擊", stateMachine, this);
            playerDead = new PlayerDead($"{name}死亡", stateMachine, this);

            traCamera = GameObject.Find("虛擬攝影機_第三人稱").transform;

            stateMachine.Initialize(playerIdle);
            #endregion

        }

        protected override void Update()
        {
            base.Update();

            //Log.Text(IsGroung());
        }

        public bool IsGroung()
        {
            return Physics.OverlapSphere(
                transform.position + Vector3.up * cheakGroundOffest, 
                cheakGroundRadius, 
                layerCanJump).Length > 0;
        }

        public void LookAtCamera()
        {
            Quaternion cameraAngle = Quaternion.Euler(0, traCamera.eulerAngles.y, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, cameraAngle, turnSpeed * Time.deltaTime);
        }
    }
}