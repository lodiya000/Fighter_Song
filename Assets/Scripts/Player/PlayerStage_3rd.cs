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

            for (int i = 0; i < 3; i++)
            {
                int index = i;

                if (Input.GetKeyDown(skills[index]))
                {
                    player.skillRing3[index].Play();
                    player.UpdateSkillCombo(2, SkillSlotManager.instance.skillTypesOrder[index]);
                    stateMachine.SwitchState(player.playerStage_Cast);
                }
            }
        }
    }
}