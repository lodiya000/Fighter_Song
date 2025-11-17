using System.Linq;
using Lodiya;
using UnityEditor.Experimental.GraphView;
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
    private SkillCombo[] allSkillCombo;

    [SerializeField]
    private Transform player;
    private Vector3 result;
    private Vector3 skill;

    [SerializeField]
    private Transform[] baseAttatkPoint;
    [SerializeField]
    private Transform skillAssignPoint;

    #region 技能預置物
    [SerializeField]
    private SkillCombo[] NormalSkillCombo;
    #endregion

    private void Awake()
    {
        player = GameObject.Find(Player.m_name).transform;
    }

    public void SkillCast(Vector3 spell)
    {
        for (int i = 0; i < allSkillCombo.Length; i++)
        {
            var playerCombo = Player.instance.skillTypes;
            var skillCombo = allSkillCombo[i];

            Log.Text(playerCombo.SequenceEqual(skillCombo.combo));  
            if (playerCombo.SequenceEqual(skillCombo.combo))
            {
            Log.Text($"{i}");
                //Instantiate(skillCombo.skillPrefab, player.position, Quaternion.identity);

                Player.instance.ani.SetFloat("攻擊類型", skillCombo.skillposture);
                Player.instance.ani.SetTrigger("詠唱攻擊");
            }
        }
    }


    /// <summary>
    /// 生成基礎攻擊
    /// </summary>
    /// <param name="index">基礎攻擊段數 0左手 1右手 2雙手</param>
    public void SpawnSkillAttatk(int index)
    {
        Log.Text("skill");

        if (Player.instance.ani.GetBool("詠唱模式"))
        {
            for (int i = 0; i < allSkillCombo.Length; i++)
            {
                var playerCombo = Player.instance.skillTypes;
                var skillCombo = allSkillCombo[i];

                //Log.Text(playerCombo.SequenceEqual(skillCombo.combo));
                if (playerCombo.SequenceEqual(skillCombo.combo))
                {
                    //Log.Text($"{i}");
                    Instantiate(skillCombo.skillPrefab, baseAttatkPoint[index].position, baseAttatkPoint[index].rotation);
                }
            }
        }
        else 
        {

            if (index < 2)
            {
                Instantiate(NormalSkillCombo[0].skillPrefab, baseAttatkPoint[index].position, baseAttatkPoint[index].rotation);
            }
            else if(index == 2) 
            {
                Instantiate(NormalSkillCombo[1].skillPrefab, baseAttatkPoint[index].position, baseAttatkPoint[index].rotation);
            }
        }

    }
}
