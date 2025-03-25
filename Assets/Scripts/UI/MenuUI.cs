using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private Image backGround;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    private void Awake()
    {
        startButton.onClick.AddListener(ChangeUI);
        quitButton.onClick.AddListener(QuitButton);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    { 
        Application.Quit();
    }
    public void ChangeUI()
    { 
        startButton.onClick.RemoveAllListeners();
        tmp.text = "11010Â·¹«½»";
        backGround.sprite = Resources.Load<Sprite>("Texture/StartMenu/BackGround");
        startButton.onClick.AddListener(StartButton);
       
    }
}
