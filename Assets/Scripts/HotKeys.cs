using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotKeys : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            GameManager.TriggerVictory();
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            GameManager.TriggerGameOver();
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            GameManager.Restart();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            GameManager.Instance.score++;
        }
    }
}