using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public Vector3 mouse_pos;
    public Animator anim;
    public bool attackable = true;
    private bool is_att;
    public float CD = 0.5f;
    void Update()
    {   if(attackable)
            Attack();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if(collision.CompareTag("Enermy"))
        collision.gameObject.GetComponent<Enermy_character>().Ondamage(1, gameObject, 1);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&is_att == false)
        {
            anim.SetBool("isattack", true);
            is_att = true;

        }
        if (is_att)
        {
            CD-=Time.deltaTime;
        }
        if (CD <= 0 && is_att == true)
        { 
            is_att = false;
            anim.SetBool("isattack", false);
            CD = 0.5f;
        }
    }
}
