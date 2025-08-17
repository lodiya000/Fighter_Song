using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    public class Character : MonoBehaviour
    {
        [field: Header("基本資料")]
        [field: SerializeField, Range(0, 5)]
        public float walkSpeed { get; private set; } = 2;
        [field: SerializeField, Range(100, 1000)]
        public float hpMax { get; private set; } = 100;
        public float hp {  get; private set; }

        #region 狀態機與狀態
        public StateMachine stateMachine { get; private set; }
        public Animator ani { get; private set; }       // 動畫控制元件 
        public Rigidbody rig { get; private set; }      // 2D 剛體元件
        #endregion

        public string damageObjectTag;

        protected virtual void Awake()
        {
            stateMachine = new StateMachine();

            ani = GetComponent<Animator>();         // 取得動畫元件 
            rig = ani.GetComponent<Rigidbody>();    // 取得剛體元件
            hp = hpMax;
        }

        protected virtual void Update()
        {
            stateMachine.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(damageObjectTag))
            {
                Damage(30);
            }
        }
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage"></param>
        protected virtual void Damage(float damage)
        {
            hp -= damage;
            Debug.Log($"{name}受到了{damage}點傷害, HP剩餘{hp}");

            if (hp <= 0) Dead();
        }
        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            Debug.Log($"{name}死亡");

        }

    }
}