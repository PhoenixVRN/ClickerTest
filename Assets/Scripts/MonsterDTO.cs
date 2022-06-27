using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Monster Data", menuName = "Monster Data", order = 51)]
public class MonsterDTO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _object;
    
    
    void Start()
    {
        
        
    }

   
    void Update()
    {
        
    }
}
