using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltransition : MonoBehaviour
{
    public void NextLevel()
    {
        //SceneManager.LoadScene(s);
        WorldController.shared.LoadGame();
    }
}
