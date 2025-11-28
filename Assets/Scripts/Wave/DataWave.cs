using UnityEngine;

[CreateAssetMenu(fileName = "DataWave", menuName = "Lodiya/DataWave", order = 2)]
public class DataWave : ScriptableObject
{
    public GameObject prefab;
    [Range(0,30)]
    public float inteeval;
    [Range(0, 100)]
    public int max;
    [Range(0,100)]
    public int spawnDistance;
    [Range(0,100)]
    public int perSpawnCount;

    /// <summary>
    /// 此波次的持續時間
    /// </summary>
    [Range(0, 600)]
    public float duration;
    /// <summary>
    /// 目前生成的數量
    /// </summary>
    public int currentCount;

    public void ResetCount() => currentCount = 0;
}
