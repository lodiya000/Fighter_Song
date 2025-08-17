using UnityEngine;

namespace Lodiya
{
    public class EnemyIdle : EnemyState
    {
        private float idleTime;

        public EnemyIdle(string _name, StateMachine _stateMachine, Enemy _enemy) : base(_name, _stateMachine, _enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.ani.SetFloat("移動", 0);
            enemy.agent.velocity = Vector3.zero;
            idleTime = Random.Range(enemy.idleRange.x, enemy.idleRange.y);
            //Log.Text($"待機時間:{idleTime}");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (timer >= idleTime) stateMachine.SwitchState(enemy.enemyWander);
        }
    }
}