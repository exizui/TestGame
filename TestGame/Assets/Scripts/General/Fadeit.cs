using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeit : MonoBehaviour
{
    public Image panel;
   public void ClosePanel()
   {
        panel.enabled= false;
   }
}
