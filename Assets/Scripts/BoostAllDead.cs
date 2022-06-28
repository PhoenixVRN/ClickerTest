using System.Collections;
using UnityEngine;

public class BoostAllDead : MonoBehaviour
{
    private MonsterManager _monsterManager;
    private Transform _monsterPooling;
    
    void Start()
    {
        _monsterPooling = GameObject.Find("MonsterPooling").transform;
        _monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
    }
    
    
    public void OnMouseDown()
    {
        if (_monsterPooling.childCount != 0)
        {
            StartCoroutine(DeadforChildren());
            Destroy(gameObject);
        }
    }

    IEnumerator DeadforChildren()
    {
       for (int i = 0; i < _monsterPooling.childCount; i++)
       {
            _monsterPooling.GetChild(i).gameObject.GetComponent<EssenceMonster>().DeadMonstres();
       }
       yield return null;
    }
}
