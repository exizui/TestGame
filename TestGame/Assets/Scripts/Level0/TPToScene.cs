
using System;
using UnityEngine;


namespace YourNamespace
{
    public class TPToScene : MonoBehaviour
    {
        /*
        public Transform SpawnLevel0;
        [SerializeField] private GameObject txtdoor;
        [SerializeField] private Transform playercamera;
        [SerializeField] private KeyCode e = KeyCode.E;
        
        private bool istp = false;
        private void OnTriggerEnter(Collider other)
        {
            istp = true;
            if (other.CompareTag("Player"))
            {
                WorldController.shared.UnloadLevel();
                WorldController.shared.LoadLevel("Level0");
               
                //other.transform.position = SpawnLevel0.position;
            }              
        }
        */
        public GameObject showObject;
        private float showAtDistance = 4f;
        private Transform fromTheObject;
        private bool canPressButton = false;
        //public string lvl;
        public static TPToScene singleton;
        public static Action OnTransit;
        private void Awake()
        {
            singleton = this;
        }

        void Start()
        {
           
            GameObject player = GameObject.Find("player");
            if (player != null)
            {
                fromTheObject = player.transform;
            }
            else
            {
                Debug.LogError("Не удалось найти объект 'player'");
            }
        }

        
        void OnMouseOver()
        {  
                if (fromTheObject)
                {
                    Vector3 offset = fromTheObject.position - transform.position;
                    float sqrLen = offset.sqrMagnitude;
                    if (sqrLen < showAtDistance * showAtDistance)
                    {
                    showObject.SetActive(true);
                    ToggleButtonPress();
                        if(canPressButton && Input.GetKey(KeyCode.E))
                        {
                              OnTransit?.Invoke(); //вызов события загрузка уровня
                        }                    
                    }          
                }  
        }

        void ToggleButtonPress()
        {
            canPressButton = !canPressButton; // Инвертируем состояние
        }
        void OnMouseExit()
        {
            showObject.SetActive(false);
        }

        void Update()
        {
            if (fromTheObject)
            {
                Vector3 offset = fromTheObject.position - transform.position;
                float sqrLen = offset.sqrMagnitude;
                if (sqrLen > showAtDistance * showAtDistance)
                    showObject.SetActive(false);
                    
            }
        }
        //private void Nextlvl(string namelvl)
        //{
        //    if (!canTptoLvl2)
        //    {
        //        showObject.SetActive(false);
        //        WorldController.shared.UnloadLevel();
        //        WorldController.shared.LoadLevel(namelvl);
        //        print(canTptoLvl2);
        //        canTptoLvl2 = true;
        //    }         
        //    if (canTptoLvl2)
        //        fromTheObject.transform.position = level2spawn;
        //}

        
    }
}

