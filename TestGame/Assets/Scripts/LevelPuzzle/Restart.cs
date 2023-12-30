using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{

    public static Restart res;
    public Restart()
    {
        res = this;
    }
    public void LevelPuzzle()
    {
        WorldController.shared.UnloadLevel();
        WorldController.shared.LoadLevel("LevelPuzzle");
    }

    public void Level3()
    {
        WorldController.shared.UnloadLevel();
        WorldController.shared.LoadLevel("Level3");
    }
}
