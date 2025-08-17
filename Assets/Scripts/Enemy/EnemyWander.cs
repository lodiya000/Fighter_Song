using UnityEngine;

namespace Lodiya
{
    public class EnemyWander : EnemyState
    {
        private float wanderTime;
        private Vector3 wanderPosition;

        public EnemyWander(string _name, StateMachine _stateMachine, Enemy _enemy) : base(_name, _stateMachine, _enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.agent.speed = enemy.walkSpeed;
            enemy.agent.stoppingDistance = 0;
            wanderTime = Random.Range(enemy.wanderRange.x, enemy.wanderRange.y);
            wanderPosition = enemy.RandomPosition(enemy.originalPosition, enemy.wanderRadius);
            //Log.Text($"遊走時間:{wanderTime}");

        }

        public override void Exit()
        {
            base.Exit();
            wanderPosition = enemy.RandomPosition(enemy.originalPosition, enemy.wanderRadius);
        }

        public override void Update()
        {
            base.Update();

            enemy.agent.destination = wanderPosition;
            enemy.ani.SetFloat("移動", enemy.agent.velocity.magnitude / enemy.walkSpeed);

            if (timer >= wanderTime) stateMachine.SwitchState(enemy.enemyIdle);
            if (enemy.IsPlayerInTrackArea()) stateMachine.SwitchState(enemy.enemyTrack);
        }
    }
}