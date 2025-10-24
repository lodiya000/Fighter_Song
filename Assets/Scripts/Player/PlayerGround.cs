using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 玩家地面狀態 : 待機、走路、跑步屬於地面狀態
    /// </summary>
    public class PlayerGround : PlayerState
    {
        public PlayerGround(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
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

            if (!inSpell && Input.GetKeyDown(KeyCode.Mouse0)) stateMachine.SwitchState(player.playerAttack);

            if (!inSpell && Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SwitchState(player.playerStage_1st); 
            }
        }
    }
}