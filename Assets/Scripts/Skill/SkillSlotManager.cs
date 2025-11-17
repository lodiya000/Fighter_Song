using Unity.VisualScripting;
using UnityEngine;

namespace Lodiya
{
    public class SkillSlotManager : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static SkillSlotManager _instance;
        //讓外部取得的窗口 (唯獨)
        public static SkillSlotManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<SkillSlotManager>();

                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 技能類型順序 : 插槽內的順序
        /// </summary>
        [SerializeField]
        private SkillType[] _skillTypesOrder;

        public SkillType[] skillTypesOrder => _skillTypesOrder;

        public SkillType Skill1 => _skillTypesOrder[0];
        public SkillType Skill2 => _skillTypesOrder[1];
        public SkillType Skill3 => _skillTypesOrder[2];

        [SerializeField]
        private SkillSlot skillSlot1;
        [SerializeField]
        private SkillSlot skillSlot2;
        [SerializeField]
        private SkillSlot skillSlot3;

        public int[] runeID; 

        private void Awake()
        {
            //測試符文順序 火 水 風
            _skillTypesOrder = new SkillType[3]
                {
                    skillSlot1.dataRune.skillType,
                    skillSlot2.dataRune.skillType,
                    skillSlot3.dataRune.skillType,
                };

            runeID = new int[3]
            {
                skillSlot1.dataRune.runeID,
                skillSlot2.dataRune.runeID,
                skillSlot3.dataRune.runeID,
            };
        }
        /// <summary>
        /// 更新技能順序 對調插槽後更新
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void UpdateSkillRune(int first, int second) 
        {
            SkillType temp = _skillTypesOrder[first];
            int id = runeID[first];

            _skillTypesOrder[first] = _skillTypesOrder[second];
            _skillTypesOrder[second] = temp;

            runeID[first] = runeID[second];
            runeID[second] = id;

        }
    }
}