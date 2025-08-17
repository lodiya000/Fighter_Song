using UnityEngine;

namespace Lodiya
{
    public class EnemyAttack : EnemyState
    {
        public EnemyAttack(string _name, StateMachine _stateMachine, Enemy _enemy) : base(_name, _stateMachine, _enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.ani.SetFloat("移動", 0);
            enemy.agent.velocity = Vector3.zero;
            enemy.ani.SetTrigger("攻擊");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (timer >= enemy.attackCD)
                stateMachine.SwitchState(enemy.enemyTrack);
        }
    }
}