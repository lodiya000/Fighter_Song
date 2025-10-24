using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 玩家狀態
    /// </summary>
    public class PlayerState : State
    {
        protected Player player;
        protected float inputH, inputV;
        protected bool inSpell = false;

        public PlayerState( string _name, StateMachine _stateMachine, Player _player)
        {
            name = _name;
            stateMachine = _stateMachine;
            player = _player;
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

            inputH = Input.GetAxis("Horizontal");  //獲得玩家的水平軸向(AD、左右)
            inputV = Input.GetAxis("Vertical");    //獲得玩家的垂直軸向(WS、上下)
        }

    }
}
