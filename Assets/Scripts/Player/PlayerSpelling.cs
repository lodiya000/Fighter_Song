using UnityEngine;

namespace Lodiya
{
    public class PlayerSpelling : PlayerState
    {
        protected static Vector3 spell;
        protected GameObject ring1, ring2, ring3;
        protected static ParticleSystem s1, s2, s3;
        protected KeyCode skillKey1 = KeyCode.Alpha1;
        protected KeyCode skillKey2 = KeyCode.Alpha2;
        protected KeyCode skillKey3 = KeyCode.Alpha3;
        protected SkillSystem skillSystem;

        public PlayerSpelling(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
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

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Reset();           

                stateMachine.SwitchState(player.playerStage_1st);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                inSpell = false;
                player.ani.SetBool("詠唱模式", false);
                Reset();
                stateMachine.SwitchState(player.playerIdle);
            }
        }

        protected void Reset()
        {
            //if(s1 = null) return;

            if (s1 != null)
            {
                s1.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                s1 = null;
                Debug.Log($"重置s1: {s1}");
            }
            if (s2 != null)
            {
                s2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                s2 = null;
                Debug.Log($"重置s2: {s2}");
            }
            if (s3 != null)
            {
                s3.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                s3 = null;
                Debug.Log($"重置s3: {s3}");
            }

            spell = new Vector3(0, 0, 0);

            Debug.Log("重置符文");
        }
    }
}