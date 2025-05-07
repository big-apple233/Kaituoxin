using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_manager : MonoBehaviour
{
    public GameObject content;
    private int id;
    private void Start()
    {
        Union();
        content.GetComponent<Content_manager>().Union();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Union()
    {
        id = content.gameObject.GetComponent<Content_manager>().id;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (id <= 9 && id >= 5)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (id == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
