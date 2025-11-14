using UnityEngine;

namespace Lodiya
{
    [SerializeField,CreateAssetMenu(menuName = "Lodiya/Skill Combo", order = 0)]
    public class SkillCombo : ScriptableObject
    {
        public SkillType[] skillTypes;
        public string skillName;
        public GameObject skillPrefab;
        public int skillposture;

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