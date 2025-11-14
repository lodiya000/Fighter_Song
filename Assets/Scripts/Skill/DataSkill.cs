using UnityEngine;

namespace Lodiya
{
    [CreateAssetMenu(fileName = "DataSkill", menuName = "Lodiya/Skill Normal", order = 0)]
    public class DataSkill : ScriptableObject
    {
        public string skillName;
        public GameObject skillPrefab;
        public int skillposture;
    }
}
