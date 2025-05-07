using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySit : MonoBehaviour
{
    public int id;
    public bool isExit;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyControl>(out EnemyControl ec))
        {
            if (ec.GetId() == this.id)
            {
                print(collision.gameObject.name + "�뿪��λ");
                isExit = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isExit)
            if (collision.TryGetComponent<EnemyControl>(out EnemyControl ec))
            {
                if (ec.GetId() == this.id)
                {
                print(collision.gameObject.name + "�ص���λ");

                    
                    collision.GetComponent<AnimationControl>().SetParameter("isWalk", false);
                    collision.GetComponent<Person_character>().isMonster = false;
                    ec.enabled = false;
                }
            }
    }
}
