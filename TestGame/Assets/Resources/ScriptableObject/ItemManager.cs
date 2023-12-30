
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{ 
 public Item[] Weapons;
  public Transform[] position;
 public static ItemManager _public;
 public TextMeshProUGUI weaponpdata;
 public bool isCanSpawn = true;
 
 private void Awake()
 {
  _public = this;
  weaponpdata = GameObject.Find("weaponData")?.GetComponent<TextMeshProUGUI>();
  if (weaponpdata != null)
  {
   // Установка RaycastTarget в false
  weaponpdata.raycastTarget = false;
  }
  else
  {
   Debug.LogError("TextMeshProUGUI component is not assigned!");
  }
 }
 
 public void SpawnWeapons()
 {
    if (isCanSpawn)
    {
        GameObject _axe = Weapons[0].Prefab;
        GameObject _hammer = Weapons[1].Prefab;
        GameObject _sword = Weapons[2].Prefab;

        Instantiate(_axe, position[0].transform.position, Quaternion.identity);
        Instantiate(_hammer, position[1].transform.position, Quaternion.identity);
        Instantiate(_sword, position[2].transform.position, Quaternion.identity);

        _axe.GetComponent<Rigidbody>().isKinematic = true;
        _hammer.GetComponent<Rigidbody>().isKinematic = true;
        _sword.GetComponent<Rigidbody>().isKinematic = true;

        isCanSpawn = false;
        
    }
 }
 private string _txt;
 public void _ConvertData(int a)
 {
   this._txt = a.ToString();
      if (a == 1) 
         _Axe();
      if (a == 2)
       _Hammer();
      if (a == 3)
       _Sword();
 } 
 public void _Axe()
 {
  var (axename, axedamage, axespeed) = (Weapons[0].Name, Weapons[0].Damage, Weapons[0].AttackSpeed);
  _txt = $"Назва:{axename} Шкода:{axedamage} Швидкість:{axespeed}";
  weaponpdata.text = _txt;
 }

 public void _Hammer()
 {
  var (hammername, hammerdamage, hammerspeed) = (Weapons[1].Name, Weapons[1].Damage, Weapons[1].AttackSpeed);
  _txt = $"Назва:{hammername} Шкода:{hammerdamage} Швидкість:{hammerspeed}";
  weaponpdata.text = _txt;
 }

 public void _Sword()
 {
  var (swordname, sworddamage, swordspeed) = (Weapons[2].Name, Weapons[2].Damage, Weapons[2].AttackSpeed);
  _txt = $"Назва:{swordname} Шкода:{sworddamage} Швидкість:{swordspeed}";
  weaponpdata.text = _txt;
 }

 public void Cleartxt()
    {
        if (weaponpdata != null)
        {
            if (weaponpdata.text.Length > 0)
            {
                weaponpdata.text = "";
            }
        }
    }

} 













#region Вывод в консоль

/*print($"axename: {axename}, axedamage: {axedamage}, axespeed: {axespeed}");
print($"hammername: {hammername}, hammerdamage: {hammerdamage}, hammerspeed: {hammerspeed}");
print($"swordname: {swordname}, sworddamage: {sworddamage}, swordspeed: {swordspeed}");

ConvertData(axename, axedamage, axespeed, hammername, hammerdamage, hammerspeed, swordname, sworddamage, swordspeed); */
#endregion


 //public void LoadWeapons()
 //{
     //Resources.LoadAll<Item>("ScriptableObject/items");
    // foreach (var item in Weapons)
     //{
      //   if (item != null && item.Prefab != null)
      //   {
       //      GameObject itemGameObject = item.Prefab;
       //      Instantiate(itemGameObject, spawnitem.transform.position, Quaternion.identity);
        //     itemGameObject.GetComponent<Rigidbody>().isKinematic = false;
      //   }
     //}
 //}