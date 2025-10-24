using UnityEngine;

namespace Lodiya
{
    public class Player : Character
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static Player _instance;
        //讓外部取得的窗口 (唯獨)
        public static Player instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<Player>();

                return _instance;
            }
        }
        #endregion

        #region 基本資料
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
        #endregion

        #region 狀態機與狀態
        public PlayerIdle playerIdle { get; private set; }
        public PlayerWalk playerWalk { get; private set; }
        public PlayerAttack playerAttack { get; private set; }
        public PlayerDead playerDead { get; private set; }
        public PlayerSpelling playerSpelling { get; private set; }
        public PlayerStage_1st playerStage_1st { get; private set; }
        public PlayerStage_2nd playerStage_2nd { get; private set; }
        public PlayerStage_3rd playerStage_3rd { get; private set; }
        public PlayerStage_Cast playerStage_Cast { get; private set; }
        #endregion

        #region 魔法環
        [SerializeField]
        public ParticleSystem s1_fire, s1_wind, s1_ice;
        [SerializeField]
        public ParticleSystem s2_fire, s2_wind, s2_ice;
        [SerializeField]
        public ParticleSystem s3_fire, s3_wind, s3_ice;
        #endregion

        #region 技能指定位置
        [Header("技能指定位置")]
        [SerializeField, Range(0, 50)]
        private float skillAssignPointLength = 5;
        [SerializeField]
        private Transform skillAssignPointOriginal;
        [SerializeField]
        private ParticleSystem psSkillAssignPoint;
        [SerializeField]
        private LayerMask skillAssignPointLayer;
        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(
                transform.position + Vector3.up * cheakGroundOffest, cheakGroundRadius);

            // 繪製技能指定位置
            if (skillAssignPointOriginal != null)
            {
                Gizmos.color = new Color(0.5f, 0.5f, 1);
                Gizmos.DrawRay(skillAssignPointOriginal.position,
                    skillAssignPointOriginal.forward * skillAssignPointLength);
            }
        }

        protected override void Awake()
        {
            base.Awake();

            #region 實例化
            playerIdle = new PlayerIdle($"{name}待機", stateMachine, this);
            playerWalk = new PlayerWalk($"{name}走路", stateMachine, this);
            playerAttack = new PlayerAttack($"{name}攻擊", stateMachine, this);
            playerDead = new PlayerDead($"{name}死亡", stateMachine, this);
            playerSpelling = new PlayerSpelling($"{name}詠唱", stateMachine, this);
            playerStage_1st = new PlayerStage_1st($"{name}詠唱", stateMachine, this);
            playerStage_2nd = new PlayerStage_2nd($"{name}詠唱", stateMachine, this);
            playerStage_3rd = new PlayerStage_3rd($"{name}詠唱", stateMachine, this);
            playerStage_Cast = new PlayerStage_Cast($"{name}詠唱", stateMachine, this);

            traCamera = GameObject.Find("虛擬攝影機_第三人稱").transform;

            stateMachine.Initialize(playerIdle);
            #endregion

            #region ring
            s1_fire.Stop();
            s1_wind.Stop();
            s1_ice.Stop();
            s2_fire.Stop();
            s2_wind.Stop();
            s2_ice.Stop();
            s3_fire.Stop();
            s3_wind.Stop();
            s3_ice.Stop();
            #endregion
        }

        protected override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// 顯示技能指定位置
        /// </summary>
        public void ShowSkillAssignPoint()
        {
            // 如果 技能指定位置 特效 還沒播放 就播放
            if (!psSkillAssignPoint.isPlaying) psSkillAssignPoint.Play();

            // 射線
            RaycastHit hit;
            Physics.Raycast(skillAssignPointOriginal.position,
                    skillAssignPointOriginal.forward,
                    out hit, skillAssignPointLength, skillAssignPointLayer);

            // 如果 射線 有打到物件 就將 技能指定位置 設定在 打到物件的點上方
            if (hit.collider != null) psSkillAssignPoint.transform.position = hit.point;
            // 否則 沒打到物件 就將 技能指定位置 設定在 射線最後
            else 
                psSkillAssignPoint.transform.position = 
                    skillAssignPointOriginal.position + 
                    skillAssignPointOriginal.forward * skillAssignPointLength;
        }

        /// <summary>
        /// 隱藏技能指定位置
        /// </summary>
        public void HideSkillAssignPoint()
        {
            psSkillAssignPoint.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
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

        public void Splling(string skil)
        {

        }

        /// <summary>
        /// 生成基礎火球
        /// </summary>
        /// <param name="index">基礎攻擊段數：0 左手、1 右手、2 雙手</param>
        private void SpawnBasicFireSmallBall(int index)
        {
            SkillSystem.instance.SpawnBasicFireSmallBall(index);
        }
    }
}