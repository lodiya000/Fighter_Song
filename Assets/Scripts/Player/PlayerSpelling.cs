using System;
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

        protected KeyCode[] siklls = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

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
            isClick = false;
        }

        private bool isClick;
        private float clickTime;

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Reset();           

                stateMachine.SwitchState(player.playerStage_1st);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isClick)
            {
                clickTime = Time.time;
                isClick = true;
                inSpell = false;
                player.ani.SetBool("詠唱模式", false);
                Reset();
            }

            if(isClick && Time.time >= clickTime + 1.2f)
                stateMachine.SwitchState(player.playerIdle);
        }

        protected void Reset()
        {
            //if(s1 = null) return;
            //player.HideSkillAssignPoint();

            for (int i = 0; i < player.skillRing1.Length; i++)
            {
                player.skillRing1[i].Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); ;
                player.skillRing2[i].Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); ;
                player.skillRing3[i].Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); ;
            }


            spell = new Vector3(0, 0, 0);

            Debug.Log("重置符文");
        }
    }
}