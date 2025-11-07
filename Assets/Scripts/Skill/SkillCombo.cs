using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 技能組合：哪三種符文組合與該技能名稱
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Skill Combo", order = 0)]
    public class SkillCombo : ScriptableObject
    {
        public SkillType[] skillTypes;
        public string skillName;
        public GameObject skillPrefab;

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
