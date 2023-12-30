using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using TMPro;
using UnityEngine;

public class TPtoFinal : MonoBehaviour
{
    private float timeUntilTp = 3f;
    public TextMeshProUGUI readoutTmp;
    public GameObject _car;

    private void OnTriggerEnter()
    {
        StartCoroutine(Readout());
    }
    IEnumerator Readout()
    {
        DeleteArrow();
        ReturnPlayer.rtpl.Return();
        readoutTmp.enabled = true;
        float timer = timeUntilTp;
        while (timer > 0f)
        {
            readoutTmp.text = timer.ToString("F1"); // Отображение времени с одним знаком после запятой
            yield return null;

            timer -= Time.deltaTime;
        }
        FinalTeleport();
    }

    private void FinalTeleport()
    {
        WorldController.shared.UnloadLevel();
        WorldController.shared.LoadLevel("TheFinal");

    }

    void DeleteArrow()
    {
        CheckPoints arrow = new CheckPoints();
        arrow.ArrowDelete();
    }
}
