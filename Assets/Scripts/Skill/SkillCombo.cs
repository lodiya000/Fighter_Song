using UnityEngine;

namespace Lodiya
{
    [SerializeField,CreateAssetMenu(menuName = "Lodiya/Skill Combo", order = 0)]
    public class SkillCombo : ScriptableObject
    {
        public SkillType[] skillTypes;
        public string skillName;
        public GameObject skillPrefab;
        //技能施放的姿勢
        public int skillposture;
        //技能施放的地點
        public SkillPoint skillPoint;

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