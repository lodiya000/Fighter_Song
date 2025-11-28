using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Lodiya
{
    public class WaveManager : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static WaveManager _instance;
        //讓外部取得的窗口 (唯獨)
        public static WaveManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<WaveManager>();

                return _instance;
            }
        }
        #endregion


        [SerializeField,Header("波數資料")]
        private DataWave[] dateWaves;

        private Transform player;
        private int index;
        private DataWave currentWave => dateWaves[index];

        private void Awake()
        {
            player = GameObject.Find("玩家").transform;

            StartCoroutine(StarWave());
        }

        private void OnDisable()
        {
            for (int i = 0; i < dateWaves.Length; i++)
                dateWaves[i].ResetCount();
        }


        private IEnumerator StarWave()
        {
            int waveCount = (int)currentWave.duration / (int)currentWave.inteeval;
            Debug.Log($"<color=#6f6>此波次會生成{waveCount}次");
            for (int i = 0; i <= waveCount; i++)
            {
                Spawn();
                Debug.Log($"<color = #ff3>生成次數:{i}次");
                yield return new WaitForSeconds(currentWave.inteeval);
            }
            Debug.Log($"<color=#3ff>第{index}波生成結束");          

            StopAllCoroutines();

            //若不為最後一波
            if(index != dateWaves.Length-1)
            {
                index++;
                StartCoroutine(StarWave());

            }
            else Debug.Log($"<color=#f3f>本次測試生成結束");
        }

        private void Spawn()
        {
            for (int i = 0;i < currentWave.perSpawnCount;i++)
            {
                if(currentWave.currentCount < currentWave.max)
                {
                    Vector3 spawnPoint = player.position + Random.onUnitSphere * currentWave.duration;
                    NavMesh.SamplePosition(spawnPoint, out NavMeshHit hit,
                        currentWave.spawnDistance * 1.5f, NavMesh.AllAreas);
                    spawnPoint = hit.position;

                    Enemy enemy = Instantiate(currentWave.prefab,spawnPoint,Quaternion.identity)
                        .GetComponent<Enemy>();
                    enemy.UpdateHP(10);
                    currentWave.currentCount++;
                }
                else Debug.Log($"<color=#f33>敵人數量已達上限{currentWave.max}");
            }
        }

        public void EnemyDead()
        {
            currentWave.currentCount--;
        }
    }
}