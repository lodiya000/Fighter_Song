using UnityEngine;

namespace Lodiya
{
    [SerializeField,CreateAssetMenu(menuName = "Lodiya/Skill Combo", order = 1)]
    public class SkillCombo : DataSkill
    {
        public SkillType[] skillTypes;
        
        /// <summary>
        /// 技能組合
        /// </summary>
        public SkillType[] combo => skillTypes;

        public SkillCombo()
        {
            skillTypes = new SkillType[3];
        }
    }
}