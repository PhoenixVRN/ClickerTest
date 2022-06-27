using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class EssenceMonster : MonoBehaviour
{
    public string _name;
    public int _health;
    public float speed;
    [SerializeField] private int _scoreDead;
    private MonsterManager _monsterManager;
    private Vector3 _movPoint;
    
    void Start()
    {
        _monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _movPoint = _monsterManager.PositionChoice();
    }

    
    void Update()
    {
      Moving();  
    }

    public void OnMouseDown()
    {
        _health -= _monsterManager.hitDamage;
        if (_health <= 0) DeadMonstr();
        
    }

    private void Moving()
    {
        if (Vector3.Distance(transform.position, _movPoint) < 10f)
        {
            _movPoint = _monsterManager.PositionChoice();
        }
        transform.position += _movPoint * speed * Time.deltaTime;
    }

    public void DeadMonstr()
    {
        _monsterManager.MonsterDead(_scoreDead);
        Destroy(gameObject);
    }
}
