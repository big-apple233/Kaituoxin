using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lattice : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ObjectSO objectSO;
    [SerializeField] private int count;
    private void Start()
    {
        image.gameObject.SetActive(false);
    }
    public void AddObject(ObjectSO objectSO)
    { 
        
        this.objectSO = objectSO;
        image.gameObject.SetActive(true);
        image.sprite = objectSO.sprite;
        count = 1;
    }
    public void ClearObject()
    {
        image.gameObject.SetActive(false);
        image.sprite = null;
        count = 0;
        this.objectSO = null;
    }
    public void AddCount()
    {
        if (objectSO == null)
            return;
        count++;
    }
    public void SubCount()
    {
        if (objectSO == null)
            return;
        if(count > 0)
            count--;
    }
    public ObjectSO GetObjectSO()
    { 
        return objectSO;
    }
}
