using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackUI : MonoBehaviour
{

    public static BackPackUI instance;
    [SerializeField] private GameObject parent;
    [SerializeField] public List<Lattice> lattices = new List<Lattice>();
    [SerializeField] private Lattice targetLattice;
    //public NameTextureSO objectSO;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //targetLattice.gameObject.SetActive(false);
        //lattices[0].AddObject(objectSO);
    }
    private void Update()
    {
        if(targetLattice.gameObject.activeSelf == true)
            targetLattice.transform.position = Input.mousePosition;
    }
    public void Show()
    { 
        parent.SetActive(true);
    }
    public void Hide()
    {
        parent.SetActive(false);

    }
    public void ChangeActive()
    { 
        parent.SetActive(!parent.activeSelf);
    }
    public void Click(Lattice lattice)
    {
        if (targetLattice.GetObjectSO() == null)
        {
            if (lattice.GetObjectSO() == null)
            {
                return;
            }
            else
            {
                targetLattice.gameObject.SetActive(true);
                targetLattice.AddObject(lattice.GetObjectSO());
                lattice.ClearObject();
            }
        }
        else
        {
            if (lattice.GetObjectSO() == null)
            {
                lattice.AddObject(targetLattice.GetObjectSO());
                targetLattice.ClearObject();
                targetLattice.gameObject.SetActive(false);
            }
            else
            { 
                NameTextureSO objectSO = lattice.GetObjectSO();
                lattice.AddObject(targetLattice.GetObjectSO());
                targetLattice.AddObject(objectSO);
            }
        }
    }
}
