using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    { 
        Application.Quit();
    }
    public void TurnToStart()
    { 
        SceneManager.LoadScene(0);
    }
}
