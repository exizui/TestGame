using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "CustomCreate/Item")]
public class Item : ScriptableObject
{
 [SerializeField]private string _Name;
 [SerializeField]private int _Damage;
 [SerializeField]private int _AttackSpeed;
 [SerializeField]private GameObject _Prefab;

 public string Name => this._Name;
 public int Damage => this._Damage;
 public int AttackSpeed => this._AttackSpeed; 
 public GameObject Prefab => this._Prefab;
}
