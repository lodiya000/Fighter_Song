using UnityEngine;

namespace Lodiya
{
    [SerializeField, CreateAssetMenu(fileName = "DataRune", menuName = "Lodiya/Rune", order = 2)]
    public class DataRune : ScriptableObject
    {
        public string runeName;
        public Sprite runeIcon;
        public SkillType skillType;

        public int runeID;
        //0 火 1 水 2風
    }
}