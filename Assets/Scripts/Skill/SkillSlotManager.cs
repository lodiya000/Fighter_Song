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

        [SerializeField]
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

        /// <summary>
        /// 更新技能類型順序：在對調插槽後更新
        /// </summary>
        /// <param name="first">要更新的第一個技能索引</param>
        /// <param name="second">要更新的第二個技能索引</param>
        public void UpdateSkillTypeSorder(int first, int second)
        {
            SkillType temp = _skillTypesOrder[first];
            _skillTypesOrder[first] = _skillTypesOrder[second];
            _skillTypesOrder[second] = temp;
        }
    }
}
