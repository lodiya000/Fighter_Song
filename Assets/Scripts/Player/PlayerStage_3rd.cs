using UnityEngine;

namespace Lodiya
{
    public class PlayerStage_3rd : PlayerSpelling
    {
        public PlayerStage_3rd(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("進入第三階段");
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
                spell.z = 1;
                s3 = player.s3_fire;
                s3.Play();
                Debug.Log($"s3: {s3}");
                stateMachine.SwitchState(player.playerStage_Cast);
            }
            else if (Input.GetKeyDown(skillKey2))
            {
                spell.z = 2;
                s3 = player.s3_wind;
                s3.Play();
                Debug.Log($"s3: {s3}");
                stateMachine.SwitchState(player.playerStage_Cast);
            }
            else if (Input.GetKeyDown(skillKey3))
            {
                spell.z = 3;
                s3 = player.s3_ice;
                s3.Play();
                Debug.Log($"s3: {s3}");
                stateMachine.SwitchState(player.playerStage_Cast);
            }
        }
    }
}