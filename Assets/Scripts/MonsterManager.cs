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
    public int hitDamage;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textMonsterCount;
    public TextMeshProUGUI textGameOver
        ;
    public bool pauseSpawn;
    
    [HideInInspector] 
    public int countMonsters;

    [HideInInspector]
    public float spawnPauseTime;
    
    [HideInInspector] 
    public int score;

    [SerializeField] private int _leftBorderSpawn, _rightBorderSpawn, _upBorderSpawn, _downBorderSpawn;
    private float _spawnSpeed;
 
    private float _spawnBoosters;
    private bool _endSpawn;
    private GameObject _poolingMonsters;
    
    void Start()
    {
        _spawnBoosters = 5f;
        score = 0;
        textScore.text = "SCORE " + score;
        countMonsters = 0;
        textMonsterCount.text = "Monsters Count " + countMonsters;
        _poolingMonsters = GameObject.Find("MonsterPooling");
        _spawnSpeed = 3f;
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
            yield return new WaitForSeconds(_spawnBoosters);
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
}
