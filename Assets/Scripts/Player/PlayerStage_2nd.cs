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

            for (int i = 0; i < 3; i++)
            {
                int index = i;

                if (Input.GetKeyDown(skills[index]))
                {
                    player.skillRing2[index].Play();
                    player.UpdateSkillCombo(1, SkillSlotManager.instance.skillTypesOrder[index]);
                    stateMachine.SwitchState(player.playerStage_3rd);
                }
            }
        }
    }
}