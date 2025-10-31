using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 技能插槽管理器
    /// </summary>
    public class SkillSlotManager : MonoBehaviour
    {
        private static SkillSlotManager _instance;

        public static SkillSlotManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<SkillSlotManager>();
                return _instance;
            }
        }

        private SkillType[] _skillTypesOrder;

        /// <summary>
        /// 技能類型順序：在插槽內的順序
        /// </summary>
        public SkillType[] skillTypesOrder => _skillTypesOrder;

        public SkillType skill1 => _skillTypesOrder[0];
        public SkillType skill2 => _skillTypesOrder[1];
        public SkillType skill3 => _skillTypesOrder[2];

        private void Awake()
        {
            // 測試順序為：火、水、風
            _skillTypesOrder = new SkillType[3] 
            { SkillType.Fire, SkillType.Water, SkillType.Wind };  
        }
    }
}
