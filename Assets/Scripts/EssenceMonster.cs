using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class EssenceMonster : MonoBehaviour
{
    public string _name;
    public int health;
    public float speed;
    [SerializeField] private int _scoreDead;
    private MonsterManager _monsterManager;
    private Vector3 _movPoint;
    public AudioSource _audioImpackt;
    public ParticleSystem blood;

    void Start()
    {
       
        _audioImpackt = gameObject.GetComponent<AudioSource>();
        _monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _movPoint = _monsterManager.PositionChoice();
    }

    
    void Update()
    {
      Moving();  
    }

    public void OnMouseDown()
    {
        _audioImpackt.Play();
        health -= _monsterManager.hitDamage;
        if (health <= 0) StartCoroutine(DeadMonstr());

    }

    private void Moving()
    {
        if (Vector3.Distance(transform.position, _movPoint) < 10f)
        {
            _movPoint = _monsterManager.PositionChoice();
        }
        transform.position += _movPoint * speed * Time.deltaTime;
    }

    public void DeadMonstres()
    {
        StartCoroutine(DeadMonstr());
    }
    public IEnumerator DeadMonstr()
    {
        Instantiate(blood, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        _monsterManager.MonsterDead(_scoreDead);
        Destroy(gameObject);
    }
}
