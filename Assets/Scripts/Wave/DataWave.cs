using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 波數資料
    /// </summary>
    [CreateAssetMenu(fileName = "DataWave", menuName = "KID/Wave", order = 2)]
    public class DataWave : ScriptableObject
    {
        public GameObject prefab;
        [Range(0, 30)]
        public float interval;
        [Range(0, 100)]
        public int max;
        [Range(0, 100)]
        public float spawnDistance;
        [Range(0, 20)]
        public int perSpawnCount;
        /// <summary>
        /// 此波數的持續時間：秒數
        /// </summary>
        [Range(0, 600)]
        public float duration;
        [Range(0, 1000)]
        public float hp;

        /// <summary>
        /// 目前生成的數量
        /// </summary>
        [HideInInspector]
        public int currentCount;

        /// <summary>
        /// 重設目前生成的數量
        /// </summary>
        public void ResetCount() => currentCount = 0;
    }
}
