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

                if (Input.GetKeyDown(siklls[index]))
                {
                    player.skillRing1[index].Play();
                    player.UpddateSkillCombo(0, SkillSlotManager.instance.skillTypesOrder[index]);
                    stateMachine.SwitchState(player.playerStage_2nd);
                }
            }
        }
    }
}