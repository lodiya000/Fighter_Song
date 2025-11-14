using Lodiya;
using UnityEngine;

public class ThunderStorm : MonoBehaviour
{
    [SerializeField]
    public GameObject thunder;
    private Transform player;
    private Vector3 result;

    private void Awake()
    {
        player = GameObject.Find(Player.m_name).transform;

        for (int i = 0; i < 20; i++)
        {
            float n = Random.Range(0, 3.0f);
            Invoke("Thunder_Storm", n);
        }

        Invoke("Delete", 10);
    }

    private void Thunder_Storm()
    {
        result = player.position + Random.insideUnitSphere * 4;
        result.y = 0;

        Instantiate(thunder, result, Quaternion.identity);
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }
}
