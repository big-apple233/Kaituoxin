using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lock_manager : MonoBehaviour
{

    public static Lock_manager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Unlock(false, 1, 0);
    }
    public void Unlock(bool ischaracter, int num, int id)
    {
        Id_det[] objects = FindObjectsOfType<Id_det>(true);
        if (ischaracter)
        {
            foreach (Id_det obj in objects)
            {

                if (obj.chara_id == id && obj.conmu_id == num)
                {
                    if (obj.gameObject.activeSelf == true)
                        continue;
                    obj.gameObject.SetActive(!obj.gameObject.activeSelf);
                    
                }
            }
        }
        else
        {
            foreach (Id_det obj in objects)
            {

                if (obj.chara_id - 10 == id)
                {
                    obj.gameObject.SetActive(!obj.gameObject.activeSelf);
                    
                }
            }
        }
    }
}
