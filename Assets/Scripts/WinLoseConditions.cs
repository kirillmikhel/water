using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseConditions : MonoBehaviour
{
    private void Update()
    {
        if (!GameManager.Instance.isGameOn) return;

        WinConditions();
        LoseConditions();

        // TODO: add your logic here
    }

    private void WinConditions()
    {
        // TODO: add your win conditions here
        return;

        GameManager.TriggerVictory();
    }

    private void LoseConditions()
    {
        // TODO: add your lose conditions here
        return;

        GameManager.TriggerGameOver();
    }

}
