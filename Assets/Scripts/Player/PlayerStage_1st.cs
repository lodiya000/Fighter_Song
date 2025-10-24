using UnityEngine;

namespace Lodiya
{
    public class PlayerStage_1st : PlayerSpelling
    {
        public PlayerStage_1st(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Reset();

            Debug.Log("進入第一階段");

            inSpell = true;
            player.ani.SetBool("詠唱模式", true);
            player.ani.SetTrigger("進入詠唱模式");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(skillKey1))
            {
                spell.x = 1;
                s1 = player.s1_fire;
                s1.Play();
                Debug.Log($"s1: {s1}");
                stateMachine.SwitchState(player.playerStage_2nd); 
            }
            else if (Input.GetKeyDown(skillKey2))
            {
                spell.x = 2;
                s1 = player.s1_wind;
                s1.Play();
                Debug.Log($"s1: {s1}");
                stateMachine.SwitchState(player.playerStage_2nd);
            }
            else if(Input.GetKeyDown(skillKey3))
            {
                spell.x = 3;
                s1 = player.s1_ice;
                s1.Play();
                Debug.Log($"s1: {s1}");
                stateMachine.SwitchState(player.playerStage_2nd);
            }
        }
    }
}