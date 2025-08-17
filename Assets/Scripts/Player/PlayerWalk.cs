using UnityEngine;

namespace Lodiya
{
    public class PlayerWalk : PlayerGround
    {
        /// <summary>
        /// 玩家走路狀態 :屬於地面狀態
        /// </summary>
        public PlayerWalk(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
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

            player.ani.SetFloat("水平", inputH);
            player.ani.SetFloat("垂直", inputV);
            player.LookAtCamera();
            player.rig.linearVelocity = 
                player.transform.right * inputH * player.walkSpeed + 
                player.transform.forward * inputV * player.walkSpeed +
                Vector3.up * player.rig.linearVelocity.y;; 

            if (inputH == 0 && inputV == 0) stateMachine.SwitchState(player.playerIdle);

            Log.Text($"{player.walkSpeed} {inputH} {inputV}");
        }
    }
}