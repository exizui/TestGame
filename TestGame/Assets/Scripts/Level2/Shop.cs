
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop inst;
    public GameObject tpback;
    public bool isSpawnedWeapons;
    private void Awake()
    {
        inst = this;
    }  
    public void Spawn()
    {
        ItemManager._public.SpawnWeapons();
        isSpawnedWeapons = !isSpawnedWeapons;
        print(isSpawnedWeapons);
        if (!isSpawnedWeapons)
            DeleteObjects();
    }

    public void DeleteObjects()
    {
        PlayerPrefs.DeleteAll();
        GameObject[] allobj = GameObject.FindGameObjectsWithTag("Weapon");      
        foreach (var all in allobj) { Destroy(all); }
        if (ItemManager._public.isCanSpawn == false)
            ItemManager._public.isCanSpawn = true;
    }

}
