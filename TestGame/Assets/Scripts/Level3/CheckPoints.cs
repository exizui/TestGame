using System;
using TMPro;
using UnityEngine;


public class CheckPoints : MonoBehaviour
{
    public Transform[] cpPosition;
    private int cpIndex;
    public TextMeshProUGUI cpTMP;
    public Color[] colorsforTMP;
    private int cpScore = 0;
    public Transform arrowSpawn;
    public GameObject arrowObj;
    public Material[] material;
    private void OnTriggerEnter(Collider other)
    {
        TransformPosition();
        cpTMP.enabled = true;
    }

    private void TransformPosition()
    {
        cpIndex++;
        cpScore += 1000;
        cpTMP.text = cpScore.ToString();
        if (cpIndex < cpPosition.Length || cpIndex < material.Length)
        {
            this.gameObject.transform.position = cpPosition[cpIndex].position;
            cpTMP.color = material[cpIndex].color;

        }


        if (cpScore == 10000) { Bublick(); }

    }


    private Vector3 scale = new Vector3(8.113412f, 4.868047f, 32.85931f);
    public GameObject finalObj;
    private void Bublick()
    {
        Destroy(this.gameObject);
        GameObject Arrow = Instantiate(arrowObj, arrowSpawn.transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Arrow.transform.localScale = scale;
        finalObj.SetActive(true);
    }

    public void ArrowDelete()
    {
        GameObject arrow = GameObject.Find("3Darrow(Clone)");
        Destroy(arrow);
    }
}
#region Мой код
/*
      //public void TransformPosition()
  //{
  //    cpIndex++;
  //    cpTMP.text = cpIndex.ToString();
  //    int i = cpIndex;
  //    switch (i)
  //    {
  //        case 1:
  //            this.gameObject.transform.position = cpPosition[1].transform.position;

  //            break;
  //        case 2:
  //            this.gameObject.transform.position = cpPosition[2].transform.position;

  //            break;
  //        case 3:
  //            this.gameObject.transform.position = cpPosition[3].transform.position;

  //            break;
  //        case 4:
  //            this.gameObject.transform.position = cpPosition[4].transform.position;

  //            break;
  //        case 5:
  //            this.gameObject.transform.position = cpPosition[5].transform.position;              
  //            break;

  //    }
  //}
 
  private void ManagePosition(int index)
  {
      if (index == 1)
          this.gameObject.transform.position = cpPosition[1].transform.position;
      if (index == 2)
          this.gameObject.transform.position = cpPosition[2].transform.position;
      if (index == 3)
          this.gameObject.transform.position = cpPosition[3].transform.position;
      if (index == 4)
          this.gameObject.transform.position = cpPosition[4].transform.position;
      if (index == 5)
          this.gameObject.transform.position = cpPosition[5].transform.position;
  }
*/
#endregion
