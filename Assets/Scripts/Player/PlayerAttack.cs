using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 玩家攻擊狀態
    /// </summary>
    public class PlayerAttack : PlayerState
    {
        /// <summary>
        /// 攻擊段數
        /// </summary>
        private int attackIndex;
        /// <summary>
        /// 最大攻擊段數  
        /// </summary>
        private int attackIndexMax = 3;
        private float[] attackAnimationTime = new float[3]
        {
            1.2F, 1.2F, 1.6F
        }; 

        public PlayerAttack(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.ani.SetTrigger("快速攻擊");

            attackIndex++;
            if (attackIndex > attackIndexMax) attackIndex = 1;

            player.ani.SetFloat("攻擊類型", attackIndex);
            player.ani.applyRootMotion = true;
        }

        public override void Exit()
        {
            base.Exit();

            player.ani.applyRootMotion = false;
        }

        public override void Update()
        {
            base.Update();

            if (timer >= attackAnimationTime[attackIndex - 1]) stateMachine.SwitchState(player.playerIdle);
        }
    }
}