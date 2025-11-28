using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Lodiya
{
    /// <summary>
    /// 波數管理器
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        private static WaveManager _instance;
        public static WaveManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<WaveManager>();
                return _instance;
            }
        }

        [SerializeField, Header("波數資料")]
        private DataWave[] dataWaves;

        private Transform player;
        private int index;
        private DataWave currentWave => dataWaves[index];
        private bool isWaveEnd;

        private void Awake()
        {
            player = GameObject.Find("玩家").transform;

            StartCoroutine(StartWave());
        }

        private void OnDisable()
        {
            for (int i = 0; i < dataWaves.Length; i++)
                dataWaves[i].ResetCount();
        }

        /// <summary>
        /// 開始波數
        /// </summary>
        /// <returns></returns>
        private IEnumerator StartWave()
        {
            int waveCount = (int)currentWave.duration / (int)currentWave.interval;
            Debug.Log($"<color=#6f6>此波會執行幾次生成：{waveCount} 次</color>");
            for (int i = 0; i <= waveCount; i++)
            {
                Spawn();
                Debug.Log($"<color=#ff3>生成次數：{i} 次</color>");
                yield return new WaitForSeconds(currentWave.interval);
            }

            Debug.Log($"<color=#11f>第 {index} 波結束！</color>");
            // 先停止所有協程
            StopAllCoroutines();
            
            // 如果索引值為最後一波 就設定為 波數結束
            if (index == dataWaves.Length - 1) isWaveEnd = true;

            // 如果波數沒結束 就開始下一波
            if (!isWaveEnd)
            {
                index++;
                StartCoroutine(StartWave());
            }
        }

        /// <summary>
        /// 生成
        /// </summary>
        private void Spawn()
        {
            for (int i = 0; i < currentWave.perSpawnCount; i++)
            {
                if (currentWave.currentCount < currentWave.max)
                {
                    // 獲得玩家生成距離並且在導覽器上的位置
                    Vector3 spawnPoint = player.position + Random.onUnitSphere * currentWave.spawnDistance;
                    NavMesh.SamplePosition(spawnPoint, out NavMeshHit hit, 
                        currentWave.spawnDistance * 1.5f, NavMesh.AllAreas);
                    spawnPoint = hit.position;
                    Enemy enemy = Instantiate(
                        currentWave.prefab, spawnPoint, Quaternion.identity).
                        GetComponent<Enemy>();
                    enemy.UpdateHp(currentWave.hp);
                    currentWave.currentCount++;
                }
                else Debug.Log($"<color=#f33>敵人數量已達上限 {currentWave.max}！</color>");
            }
        }

        /// <summary>
        /// 敵人死亡
        /// </summary>
        public void EnemyDead()
        {
            currentWave.currentCount--;
        }
    }
}
