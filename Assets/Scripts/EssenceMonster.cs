using System.Collections;
using UnityEngine;

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
    private bool _isDead;

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
        if(_isDead) return;
        _audioImpackt.Play();
        health -= _monsterManager.hitDamage;
        if (health <= 0) StartCoroutine(DeadMonstr());

    }

    private void Moving()
    {
        if (Vector3.Distance(transform.position, _movPoint) < 0.2f)
        {
            _movPoint = _monsterManager.PositionChoice();
        }
        transform.position = Vector3.MoveTowards(transform.position, _movPoint, speed * Time.deltaTime);
        transform.LookAt(_movPoint);
    }

    public void AllDead()
    {
        StartCoroutine(DeadMonstr());
    }
  
     IEnumerator DeadMonstr()
    {
        _isDead = true;
        var part = Instantiate(blood, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Destroy(part.gameObject);
        _monsterManager.MonsterDead(_scoreDead);
        Destroy(gameObject);
    }

     private void Exit()
     {
         
     }
}
