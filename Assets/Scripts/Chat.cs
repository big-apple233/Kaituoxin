using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class Chat : MonoBehaviour
{
    public int id = 0;
    public GameObject Yes,No;
    public GameObject good, bad;
    public GameObject vid;
    private void Start()
    {
        print(gameObject.transform.GetChild(0).name);
        print(gameObject.transform.GetChild(1).name);
        vid = GameObject.Find("Video Player");
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0)&&id<gameObject.transform.childCount)
        {
            Next();
        }
        if (gameObject.name == "Pub"&&id == gameObject.transform.childCount-1)
        { 
            Yes.SetActive(true);
            No.SetActive(true);
        }
    }
    public void Union()
    {
        if (id == gameObject.transform.childCount)
        {
            if (gameObject.name != "Pub")
            {
                if (gameObject.name == "Ok")
                {
                   
                    Invoke("Play", 1f);
                    good.SetActive(true);
                    Invoke("Return", 20f);
                }
                else
                { 
                    bad.SetActive(true);
                    Invoke("Return", 2f);
                }
                    
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        for (int i = 0;i<gameObject.transform.childCount;i++)
        {

            if (i == id)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);

            }
            else
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void Next()
    {
        id++;
        Union();
    }
    public void Play()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        vid.GetComponent<VideoPlayer>().Play();
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
