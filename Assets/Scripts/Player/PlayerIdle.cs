using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 玩家待機狀態 :屬於地面狀態
    /// </summary>
    /// </summary>
    public class PlayerIdle : PlayerGround
    {
        public PlayerIdle(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            inputJump = true;
            player.ani.SetFloat("水平", 0);
            player.ani.SetFloat("垂直", 0);
            player.rig.linearVelocity = Vector3.zero;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (inputH != 0 || inputV != 0) stateMachine.SwitchState(player.playerWalk);
        }
    }
}