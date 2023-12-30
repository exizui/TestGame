using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerForFigure : MonoBehaviour
{
    public static int FigureValue = 0;
    //public TMP_Text Figure;
    [HideInInspector] public GameObject[] HidedWalls;
    private List<GameObject> objecttodestroy = new List<GameObject>();
    [Header("Обжекты")]
    public GameObject Ruby;
    public GameObject zapovnimene;
    public GameObject figval3dtxt;
    public TextMeshPro FigVal;
    public GameObject Light, stairs;
    private void Start()
    {
        figval3dtxt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       MeshCollider meshcolider = other.GetComponent<MeshCollider>();

        zapovnimene.SetActive(false);
        figval3dtxt.SetActive(true);
        FigureValue++;//ВРЕМЕННО     
        SoundManager.Instance.GigureGive();
        if (meshcolider) 
        {           
            objecttodestroy.Add(other.gameObject);
            DestroyObjectsInTrigger();         
            FigVal.text = FigureValue.ToString();
            if (FigureValue == 10)
            {
                ShowRuby();
                stairs.SetActive(true);
            }        
        }
        
        if (other.CompareTag("Drag") && FigureValue == 10)
        {
            // Получаем все объекты с тегом "Drag"
            GameObject[] dragObjects = GameObject.FindGameObjectsWithTag("Drag");

            // Проходимся по всем объектам и меняем isKinematic на false
            foreach (GameObject obj in dragObjects)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }
        }
        
    }

    public void DestroyObjectsInTrigger()
    {
       
        foreach (GameObject obj in objecttodestroy)
        {

            Destroy(obj);
        }
        // Очищаем список после уничтожения объектов
        objecttodestroy.Clear();
    }

    private void ShowRuby()
    { 
        Light.SetActive(true);
        foreach (GameObject wall in HidedWalls)
        {
            wall.SetActive(false);
            Ruby.SetActive(true);
        }
    }
}
