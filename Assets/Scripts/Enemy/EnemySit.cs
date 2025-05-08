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
                print(collision.gameObject.name + "离开座位");
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
                    
                    print(collision.gameObject.name + "回到座位");

                    
                    collision.GetComponent<AnimationControl>().SetParameter("isWalk", false);
                    collision.GetComponent<Person_character>().isMonster = false;
                    collision.GetComponent<Person_character>().isSit = true;
                    var ID = collision.GetComponent<id>();
                    Lock_manager.instance.Unlock(true, 4, ID.objectId);
                    Lock_manager.instance.Unlock(true, 5, ID.objectId);
                    Lock_manager.instance.Unlock(true, 6, ID.objectId);

                    ec.enabled = false;
                }
            }
    }
}
