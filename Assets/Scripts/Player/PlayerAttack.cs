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
        private int attackIndexMax = 4;
        private float[] attackAnimationTime = new float[4]
        {
            0.6f, 1.067f, 0.733f, 1.267f
        }; 

        public PlayerAttack(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.ani.SetTrigger("攻擊");

            attackIndex++;
            if (attackIndex > attackIndexMax) attackIndex = 1;

            player.ani.SetFloat("攻擊連段", attackIndex);
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