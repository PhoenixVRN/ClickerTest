using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> monster;
    public List<GameObject> boosters;
    [Space]
    public int hitDamage;
    
    [Space]
    public ScoreData scorData;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textMonsterCount;
    public TextMeshProUGUI textGameOver;

    [HideInInspector]
    public bool pauseSpawn;

    [HideInInspector] 
    public int countMonsters;

    [HideInInspector]
    public float spawnPauseTime;
    
    [HideInInspector] 
    public int score;

    [SerializeField, Header("Диапазон границ для спавна")]
    private int _leftBorderSpawn;
    [SerializeField]
    private int _rightBorderSpawn;
    [SerializeField]
    private int _upBorderSpawn;
    [SerializeField]
    private int _downBorderSpawn;

    [Header("Периоды спавна бустеров")]
    public float spawnBoosters;
    
    [SerializeField, Header("Начальный период спавна врагов")]
    private float _spawnSpeed;
    
    private bool _endSpawn;
    private GameObject _poolingMonsters;
    
    void Start()
    {
        score = 0;
        textScore.text = "SCORE " + score;
        countMonsters = 0;
        textMonsterCount.text = "Monsters Count " + countMonsters;
        _poolingMonsters = GameObject.Find("MonsterPooling");
        StartCoroutine(SpawnMonsters());
        StartCoroutine(SpawnBoosters());
    }

   
    void Update()
    {
        
    }

    IEnumerator SpawnBoosters()
    {
        while (!_endSpawn)
        {
            yield return new WaitForSeconds(spawnBoosters);
            var mons = Instantiate(MonsterChoice(boosters), PositionChoice(), Quaternion.identity);
        }
    }
    IEnumerator SpawnMonsters()
    {
        while (!_endSpawn)
        {
            yield return new WaitForSeconds(_spawnSpeed);
            if (pauseSpawn) yield return new WaitForSeconds(spawnPauseTime);
            
                countMonsters ++;
                textMonsterCount.text = "Monsters Count " + countMonsters;
                if (countMonsters > 10)
                {
                    _endSpawn = true;
                    StartCoroutine(GameOver());
                }
                var mons = Instantiate(MonsterChoice(monster), PositionChoice(), Quaternion.identity);
                mons.transform.SetParent(_poolingMonsters.transform);
                EssenceMonster monsterData = mons.GetComponent<EssenceMonster>();
                monsterData.health += score;
                monsterData.speed += score / 100;
                _spawnSpeed -= score / 100;
                pauseSpawn = false;
        }
    }

    private GameObject MonsterChoice(List<GameObject> obj)
    {
      GameObject mons  = obj[Random.Range(0, obj.Count)];
        return mons;
    }

    public Vector3 PositionChoice()
    {
        Vector3 pos = new Vector3(Random.Range(_leftBorderSpawn, _rightBorderSpawn),
            0f, Random.Range(_downBorderSpawn, _upBorderSpawn));
        pos.y = 0.5f;
        return pos;
    }

    public void MonsterDead(int scoreDead)
    {
        score += scoreDead;
        LevelUp();
        if (score > scorData.scoreData)
            scorData.scoreData = score;
        textScore.text = "SCORE " + score;
        countMonsters--;
        textMonsterCount.text = "Monsters Count " + countMonsters;
    }

    IEnumerator GameOver()
    {
        textGameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        textGameOver.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LevelUp()
    {
        
    }
}
