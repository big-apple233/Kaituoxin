using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Person_character person_Character;
    public GameObject dieui;
    private void Awake()
    {
        person_Character = GetComponent<Person_character>();
    }
    private void Update()
    {
        if (person_Character.IsDead())
        { 
            dieui.SetActive(true);
        }
    }
}
