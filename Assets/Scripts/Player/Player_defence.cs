using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_defence : MonoBehaviour
{
    public int HP;
    public float CD = 0.2f;
    public bool isdefence;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
            Invoke("Defence",0.2f);
    }
    public void Be_attacked()
    {
        if (isdefence)
            print("¸ñµ²³É¹¦");
        else
            HP -= 1;
    
    }
    private void Defence()
    { 
        isdefence = true;
        Invoke("Not_defence", 0.1f);
    }
    private void Not_defence()
    {
        isdefence = false;
    }
}
