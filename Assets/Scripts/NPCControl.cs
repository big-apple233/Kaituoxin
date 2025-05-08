using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    public int chapterIndex;
    public int npcIndex;
    public List<GameObject> chapter1;
    public List<GameObject> chapter2;
    public List<GameObject> chapter3;
    private void Start()
    {
        chapterIndex = 1;
    }
    public void NextChapter()
    {
        foreach (GameObject chapter in chapter1)
        {
            chapter.SetActive(false);
        }
        foreach (GameObject chapter in chapter2)
        {
            chapter.SetActive(false);
        }
        foreach (GameObject chapter in chapter3)
        {
            chapter.SetActive(false);
        }
        if (chapterIndex == 1)
        {
            chapter1[0].SetActive(true);
        }
        else if (chapterIndex == 2)
        {
            chapter2[0].SetActive(true);
        }
        else
        {
            chapter3[0].SetActive(true);
        }
    }
}
