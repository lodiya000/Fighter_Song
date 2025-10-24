using Lodiya;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    private static SkillSystem _instance;
    public static SkillSystem instance
    {
        get
        {
            if (_instance == null) _instance = FindAnyObjectByType<SkillSystem>();

            return _instance;
        }
    }

[SerializeField]
    private Transform player;
    private Vector3 result;

    [SerializeField]
    private Transform[] baseAttatkPoint;

    #region 技能預置物
    [SerializeField]
    public GameObject fireEnergy, windEnergy, iceEnergy;
    [SerializeField]
    public GameObject fireBall_Small, fireBall_Middle, fireBall_Large;
    [SerializeField]
    public GameObject flame, fireStorm;
    [SerializeField]
    public GameObject heal, thunder;
    [SerializeField]
    public GameObject iceSpine, waterImpact, bubbleBurst;
    #endregion

    private void Awake()
    {
        player = GameObject.Find(Player.m_name).transform;
    }

    public void SkillCast(Vector3 spell)
    {
        if(spell.x == 1)
        {
            if (spell.y == 1)
            {
                if (spell.z == 1)
                {
                    GameObject fireball =  Instantiate(fireBall_Small, player.transform);
                    fireball.transform.parent = null;
                }
                else if (spell.z == 2)
                {
                    GameObject fireball = Instantiate(fireBall_Middle, player.transform);
                    fireball.transform.parent = null;
                }
                else if (spell.z == 3)
                {
                    GameObject fireball = Instantiate(fireBall_Large, player.transform);
                    fireball.transform.parent = null;
                }
            }
            else if (spell.y == 2)
            {
                if (spell.z == 1)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 2)
                {
                    Transform p = GameObject.Find("Skeleton").transform;
                    Instantiate(flame, p.position, Quaternion.identity);
                }
                else if (spell.z == 3)
                {
                    Debug.Log("施放失敗");
                }
            }
            else if (spell.y == 3)
            {
                if (spell.z == 1)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 2)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 3)
                {
                    Transform p = GameObject.Find("Skeleton").transform;
                    Instantiate(fireStorm, p.position, Quaternion.identity);
                }
            }
        }
        else if (spell.x == 2)
        {
            if (spell.y == 1)
            {
                if (spell.z == 1)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 2)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 3)
                {
                    Debug.Log("施放失敗");
                }
            }
            else if (spell.y == 2)
            {
                if (spell.z == 1)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 2)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 3)
                {
                    Transform p = GameObject.Find("Skeleton").transform;
                    Instantiate(waterImpact, p.position, Quaternion.identity);
                }
            }
            else if (spell.y == 3)
            {
                if (spell.z == 1)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 2)
                {
                    Transform p = GameObject.Find("Skeleton").transform;
                    Instantiate(bubbleBurst, p.position, Quaternion.identity);
                }
                else if (spell.z == 3)
                {
                    Debug.Log("施放失敗");
                }
            }
        }
        else if (spell.x == 3)
        {
            if (spell.y == 1)
            {
                if (spell.z == 1)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 2)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 3)
                {
                    Debug.Log("施放失敗");
                }
            }
            else if (spell.y == 2)
            {
                if (spell.z == 1)
                {
                    Instantiate(heal, player.transform);
                }
                else if (spell.z == 2)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 3)
                {
                    Debug.Log("施放失敗");
                }
            }
            else if (spell.y == 3)
            {
                if (spell.z == 1)
                {
                    Transform p = GameObject.Find("Skeleton").transform;
                    Instantiate(thunder, p.position, Quaternion.identity);
                }
                else if (spell.z == 2)
                {
                    Debug.Log("施放失敗");
                }
                else if (spell.z == 3)
                {
                    for (int i = 0; i < 20; i++) 
                    {
                        float n = Random.Range(0, 3.0f);
                        Invoke("ThunderStorm", n);
                    }   

                }
            }
        }

    }

    private void ThunderStorm() 
    {
        result = player.position + Random.insideUnitSphere * 4;
        result.y = 0;

        Instantiate(thunder, result, Quaternion.identity);
    }

    /// <summary>
    /// 生成基礎攻擊
    /// </summary>
    /// <param name="index">基礎攻擊段數 0左手 1右手 2雙手</param>
    public void SpawnBasicAttatk(int index)
    {
        if(index < 2)
        {
            Instantiate(fireBall_Small, baseAttatkPoint[index].position, baseAttatkPoint[index].rotation);
        }
        else if(index == 2) 
        {
            Instantiate(fireBall_Large, baseAttatkPoint[index].position, baseAttatkPoint[index].rotation);
        }
    }
}
