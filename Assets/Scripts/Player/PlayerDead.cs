using UnityEngine;

namespace Lodiya
{
    public class PlayerDead : PlayerState
    {
        /// <summary>
        /// 玩家死亡狀態
        /// </summary>
        public PlayerDead(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}