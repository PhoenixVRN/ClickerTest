using UnityEngine;

public class BoostPauseSpawn : MonoBehaviour
{
    [Header("Время паузы спавна")]
    public float spawnPause;
    
    private MonsterManager _monsterManager;
    
    void Start()
    {
        _monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
    }
    
    
    public void OnMouseDown()
    {
        _monsterManager.pauseSpawn = true;
        _monsterManager.spawnPauseTime = spawnPause;
        Destroy(gameObject);
    }
}
