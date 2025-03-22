using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickManager : MonoBehaviour
{

    private RaycastHit2D hit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log("����������");
            if (hit.collider == null)
            {
                Debug.LogWarning("û�м�⵽����");
                return;
            }
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (hit.transform.CompareTag("InteractableObject"))
                {
                    Debug.Log("��⵽�ɻ�������");
                    ClickDialog();
                }
            }
           
            //else if(EventSystem.current.IsPointerOverGameObject())
            //{
            //    if (!EventSystem.current.currentSelectedGameObject.CompareTag("Lattice"))
            //        return;
            //    Lattice lattice = EventSystem.current.currentSelectedGameObject.GetComponent<Lattice>();
            //    Debug.Log("��⵽��������");
            //    ClickLattice(lattice);
            //}

            
        }
    }
    public void ClickDialog()
    {       
        InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
        DialogUI.Instance.SetText(interactableObject.GetText());
        DialogUI.Instance.Show();
    }

    
}
