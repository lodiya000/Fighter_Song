using UnityEngine;

namespace Lodiya
{
    public class PlayerStage_Cast : PlayerSpelling
    {
        public PlayerStage_Cast(string _name, StateMachine _stateMachine, Player _player) : base(_name, _stateMachine, _player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            skillSystem = GameObject.Find("技能管理器").GetComponent<SkillSystem>();

            Debug.Log("進入施放階段");
            Debug.Log($"Spell: {spell}");

        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            player.ShowSkillAssignPoint();
            base.Update();
            
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                skillSystem.SkillCast(spell);

                if (spell == new Vector3(1, 1, 1) || spell == new Vector3(1, 1, 2) || spell == new Vector3(1, 1, 3))
                {
                    player.ani.SetFloat("攻擊類型", 3);
                    player.ani.SetTrigger("詠唱攻擊");
                }
                else if (spell == new Vector3(1, 2, 2) || spell == new Vector3(1, 2, 3) || spell == new Vector3(2, 2, 3) || spell == new Vector3(2, 3, 2) || spell == new Vector3(3, 3, 1))
                {
                    player.ani.SetFloat("攻擊類型", 4);
                    player.ani.SetTrigger("詠唱攻擊");
                }
                else if (spell == new Vector3(3, 2, 1) || spell == new Vector3(3, 3, 3))
                {
                    player.ani.SetFloat("攻擊類型", 5);
                    player.ani.SetTrigger("詠唱攻擊");
                }

                stateMachine.SwitchState(player.playerStage_1st);
            }
        }
    }
}
/// 第一個符文為屬性 分別是 火 水/冰 風/雷
/// 第二個符文為分支 分別是 子彈(球) 定點 周圍 
/// 第三個符文為規模 部分會改變施放方式
/// 只有正確的組合能成功施放
/// 
/// 火
/// 111 小火球 / 112 中火球 / 113 大火球
/// 121 XXX   / 122  焚燒  / 123  XXX
/// 131 XXX   / 132  XXX   / 133  火焰風暴
/// 水/冰
/// 211   /// 212   /// 213  
/// 221   /// 222   /// 223 水流衝擊
/// 231   /// 232 泡沫爆破 / 233 
/// 風(雷)
/// 311   /// 312   /// 313  
/// 321 治療  / 322  / 323
/// 331 落雷  / 332  / 333 閃電風暴
