using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    //[SerializeField] private TMP_Text tmp;
    [SerializeField] private GameObject twoPerson;
    [SerializeField] private Image backGround;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Bus bus;
    [SerializeField] private Image tittle;
    [SerializeField] private Sprite sprite;
    private bool isChangeScene = false;
    private bool isBusFront = false;
    private void Awake()
    {
        //startButton.onClick.AddListener(ChangeUI);
        startButton.onClick.AddListener(BusMove);
        quitButton.onClick.AddListener(QuitButton);
    }

    private void BusMove()
    {
        if (isBusFront == false)
            StartCoroutine(BusFront());
    }
    private IEnumerator BusFront()
    {
        bus.StartBusMove(1500);
        yield return new WaitForSeconds(3.5f);
        twoPerson.SetActive(false);
        bus.StartBusMove(3000);
        yield return new WaitForSeconds(4.5f);
        ChangeUI();
    }
    public void StartButton()
    {
        bus.StartBusMove(-3000);
        if (isChangeScene == false)
        {
            isChangeScene = true;
            StartCoroutine(ChangeScene());
        }
    }
    public void QuitButton()
    { 
        Application.Quit();
    }
    public void ChangeUI()
    { 
        startButton.onClick.RemoveAllListeners();
        //tmp.text = "11010Â·¹«½»";
        backGround.GetComponent<Animator>().SetBool("isRealStart", true);
        tittle.sprite = sprite;
        startButton.onClick.AddListener(StartButton);
        startButton.GetComponentInChildren<TMP_Text>().color= new Color(1.0f * 185 / 255, 1.0f * 105 / 255, 1.0f * 138 / 255, 1);
        quitButton.GetComponentInChildren<TMP_Text>().color = new Color(1.0f * 185 / 255, 1.0f * 105 / 255, 1.0f * 138 / 255, 1);

    }
    private IEnumerator ChangeScene()
    { 
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }

}
