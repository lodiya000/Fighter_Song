using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 符文資料
    /// </summary>
    [CreateAssetMenu(fileName = "DataRune", menuName = "KID/Rune", order = 2)]
    public class DataRune : ScriptableObject
    {
        public string runeName;     // 符文名稱
        public Sprite runeIcon;     // 符文圖示
        public SkillType runeType;  // 符文類型
    }
}
