using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 技能物件
    /// </summary>
    public class SkillObject : MonoBehaviour
    {
        [SerializeField, Header("技能傷害"), Range(0, 100)]
        private float _damage = 30;

        /// <summary>
        /// 技能傷害
        /// </summary>
        public float damage => _damage;
    }
}
