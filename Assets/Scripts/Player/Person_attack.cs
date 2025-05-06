using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_attack : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int damage;
    [SerializeField] private float repelDistance;
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private float forwardSwing;

    public void SetOffset(Vector2 offset)
    { 
        this.offset.x = offset.x;
        this.offset.y = offset.y;
    }
    public void Attack()
    {
        print(this.gameObject.name + "³¢ÊÔ¹¥»÷");
        StartCoroutine(StartAttack());
        
    }
    private IEnumerator StartAttack()
    { 
        yield return new WaitForSeconds(forwardSwing);
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position + offset, attackRadius, attackLayer);
        foreach (Collider2D collider2D in collider2Ds)
        {
            collider2D.GetComponent<Person_character>().Ondamage(damage, this.gameObject, repelDistance);
            if (this.transform.position.x < collider2D.transform.position.x)
                collider2D.GetComponent<AnimationControl>().SetParameter("AffectDir", -1);
            else
                collider2D.GetComponent<AnimationControl>().SetParameter("AffectDir", 1);
            collider2D.GetComponent<AnimationControl>().SetParameter("isAffect");
        }

        //print("¹¥»÷µ½ÁË" + collider2D.name);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + offset,attackRadius);
    }
}
