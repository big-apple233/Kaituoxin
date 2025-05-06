using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lock_manager : MonoBehaviour
{


    public static void Unlock(bool ischaracter, int num, int id)
    {
        Id_det[] objects = FindObjectsOfType<Id_det>(true);
        if (ischaracter)
        {
            foreach (Id_det obj in objects)
            {

                if (obj.chara_id == id && obj.conmu_id == num)
                {
                    obj.gameObject.SetActive(!obj.gameObject.activeSelf);
                    break;
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
                    break;
                }
            }
        }
    }
}
