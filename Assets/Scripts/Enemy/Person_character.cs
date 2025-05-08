using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_character : MonoBehaviour
{   public float HP;
    [SerializeField] private float affectedCd;
    private bool isDead;
    private bool isAffected;
    public bool isMonster;
    public bool isSit;
    public void Ondamage(int damage,GameObject souce,float distance)
    {
        if (HP <= 0)
        {
            isDead = true;
            return;
        }
        print(gameObject.name + "ÊÜµ½ÁËÉËº¦");
        if(isAffected == false)
            StartCoroutine(Damage());
        HP -= damage;
        isMonster = true;
        transform.position += (gameObject.transform.position - souce.transform.position).normalized * distance;
    }
    private IEnumerator Damage()
    {
        isAffected = true;
        yield return new WaitForSeconds(affectedCd);
        isAffected = false;
    }
    public bool IsDead()
    {
        return isDead;
    }
    public bool IsAffected()
    {
        return isAffected;
    }
    public bool IsMonster() 
    { 
        return isMonster;
    }
}
