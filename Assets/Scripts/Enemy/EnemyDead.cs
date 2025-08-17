using UnityEngine;

namespace Lodiya
{
    public class EnemyDead : EnemyState
    {
        public EnemyDead(string _name, StateMachine _stateMachine, Enemy _enemy) : base(_name, _stateMachine, _enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();
            enemy.ani.SetTrigger("死亡");
            enemy.rig.linearVelocity = Vector3.zero;
            enemy.agent.velocity = Vector3.zero;
            enemy.col.enabled = false;
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