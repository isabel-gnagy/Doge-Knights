using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startNewGame : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_1_FinalVersion");
        SceneManager.UnloadSceneAsync("GameEnd");
    }
}
