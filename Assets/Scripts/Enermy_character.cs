using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_character : MonoBehaviour
{   public float HP;
    public void Ondamage(int damage,GameObject souce,float distance)
    {
        HP -= damage;
        transform.position += (gameObject.transform.position - souce.transform.position).normalized * distance*0.7f;
    }
}
