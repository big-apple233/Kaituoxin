using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterControl : MonoBehaviour
{
    public static ChapterControl instance;
    public int chapterIndex;
    public int npcIndex;
    public List<GameObject> chapter1Person;
    public List<NameTextureSO> chpater1SO;

    public List<GameObject> chapter2Person;
    public List<NameTextureSO> chpater2SO;


    public List<GameObject> chapter3Person;
    //public List<NameTextureSO> chpater3SO;

    public List<GameObject> chapterProp;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //chapterIndex = 1;
        NextChapter();
    }
    private void Update()
    {
        if (CheckChapter())
            NextChapter();
        if (CheckPerson())
        {
            NextPerson();
        }
        
    }
    public void NextChapter()
    {
        print(chapterIndex);
        npcIndex = 0;
        foreach (GameObject chapter in chapter1Person)
        {
            chapter.SetActive(false);
        }
        foreach (GameObject chapter in chapter2Person)
        {
            chapter.SetActive(false);
        }
        foreach (GameObject chapter in chapter3Person)
        {
            chapter.SetActive(false);
        }
        for (int i = 0; i < chapterProp.Count; i++)
        {
            if (chapterProp[i] != null)
            { 
                if(i == chapterIndex - 1)
                {
                    chapterProp[i].SetActive(true);
                }
                else
                {
                    chapterProp[i].SetActive(false);
                }
            }
        }
        foreach (var lattice in BackPackUI.instance.lattices)
        { 
            lattice.ClearObject();
        }
        if (chapterIndex == 1)
        {
            chapter1Person[0].SetActive(true);
            for(int i = 0; i < 10; i++)
            {
                BackPackUI.instance.lattices[i].AddObject(chpater1SO[i]);

            }
            print("第一关");
        }
        else if (chapterIndex == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                BackPackUI.instance.lattices[i].AddObject(chpater2SO[i]);

            }
            chapter2Person[0].SetActive(true);
            print("第二关");
        }
        else if (chapterIndex == 3)
        {
            
            chapter3Person[0].SetActive(true);
            print("第三关");
        }
        else
        {
            SceneManager.LoadScene("End");
        }
        chapterIndex++;
    }
    public bool CheckChapter()
    {
        if (chapterIndex == 2)
        {
            foreach (var person in chapter1Person)
            {
                var character = person.GetComponent<Person_character>();
                if (character.isSit == false && character.IsDead() == false)
                    return false;
            }
            return true;
        }
        else if (chapterIndex == 3)
        {
            foreach (var person in chapter2Person)
            {
                var character = person.GetComponent<Person_character>();
                if (character.isSit == false && character.IsDead() == false)
                    return false;
            }
            return true;
        }
        else if(chapterIndex == 4)
        {
            foreach (var person in chapter3Person)
            {
                var character = person.GetComponent<Person_character>();
                if (character.isSit == false && character.IsDead() == false)
                    return false;
            }
            return true;
        }
        return false;
    }
    public void NextPerson()
    {
        if (chapterIndex == 2)
        {
           
            
                if(npcIndex + 1 < chapter1Person.Count)
                    chapter1Person[++npcIndex].SetActive(true);
            
        }
        else if (chapterIndex == 3)
        {
            
            
                if (npcIndex + 1 < chapter2Person.Count)
                    chapter2Person[++npcIndex].SetActive(true);
            
        }
        else if (chapterIndex == 4)
        {
           
                if (npcIndex + 1 < chapter3Person.Count)
                    chapter3Person[++npcIndex].SetActive(true);
            
        }
    }
    public bool CheckPerson()
    {
        if (chapterIndex == 2)
        {
            if (chapter1Person[npcIndex].activeSelf == false || chapter1Person[npcIndex].GetComponent<Person_character>().isSit == true)
                return true;
        }
        else if (chapterIndex == 3)
        {
            if (chapter2Person[npcIndex].activeSelf == false || chapter2Person[npcIndex].GetComponent<Person_character>().isSit == true)
                return true;
        }
        else if (chapterIndex == 4)
        {
            if (chapter3Person[npcIndex].activeSelf == false || chapter3Person[npcIndex].GetComponent<Person_character>().isSit == true)
                return true;
        }
        return false;
    }
}
