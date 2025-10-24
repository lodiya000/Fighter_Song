using UnityEngine;

namespace Lodiya
{
    public class PlayerStage_2nd : PlayerSpelling
    {
        public PlayerStage_2nd(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("進入第二階段");

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
                spell.y = 1;
                s2 = player.s2_fire;
                s2.Play();
                Debug.Log($"s2: {s2}");
                stateMachine.SwitchState(player.playerStage_3rd);
            }
            else if (Input.GetKeyDown(skillKey2))
            {
                spell.y = 2;
                s2 = player.s2_wind;
                s2.Play();
                Debug.Log($"s2: {s2}");
                stateMachine.SwitchState(player.playerStage_3rd);
            }
            else if (Input.GetKeyDown(skillKey3))
            {
                spell.y = 3;
                s2 = player.s2_ice;
                s2.Play();
                Debug.Log($"s2: {s2}");
                stateMachine.SwitchState(player.playerStage_3rd);
            }
        }
    }
}