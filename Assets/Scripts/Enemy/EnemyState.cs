using UnityEngine;

namespace Lodiya
{
    public class EnemyState : State
    {
        protected Enemy enemy;

        public EnemyState(string _name, StateMachine _stateMachine, Enemy _enemy)
        {
            name = _name;
            stateMachine = _stateMachine;
            enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();

            //Log.Text($"敵人: 進入<{name}>狀態");
        }
    }
}