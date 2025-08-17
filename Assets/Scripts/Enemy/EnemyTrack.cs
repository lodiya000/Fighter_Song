using UnityEngine;

namespace Lodiya
{
    public class EnemyTrack : EnemyState
    {
        public EnemyTrack(string _name, StateMachine _stateMachine, Enemy _enemy) : base(_name, _stateMachine, _enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.agent.speed = enemy.trackSpeed;
            enemy.agent.stoppingDistance = enemy.attackDistance;
            enemy.agent.destination = enemy.player.position;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            enemy.agent.destination = enemy.player.position;
            enemy.ani.SetFloat("移動", enemy.agent.velocity.magnitude / enemy.trackSpeed * 2);

            if (enemy.agent.remainingDistance <= enemy.attackDistance)
                stateMachine.SwitchState(enemy.enemyAttack);
        }
    }
}