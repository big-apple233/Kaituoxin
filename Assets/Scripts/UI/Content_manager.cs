using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Content_manager : MonoBehaviour
{
    public GameObject back_manager;
    public int len, id;
    private void Awake()
    {
        len = gameObject.transform.childCount;
    }
    public void Jump(int num)
    {
        id = num;
        Union();
        back_manager.GetComponent<back_manager>().Union();
    }
    public void paging(bool next)
    {   if (next)
        {
            if (id == len)
                return;
        }
        else
        {
            if (id == 0)
                return;
        }
        if (next) id++;
        else id--;
        Union();
        back_manager.GetComponent<back_manager>().Union();
    }
    public void back()
    {
        id = 0;
        Union();
        back_manager.GetComponent<back_manager>().Union();
    }
    public void Union()
    {
        for (int i = 0; i < len; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(id).gameObject.SetActive(true);
        
    }
}
