using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLattices : MonoBehaviour
{
    public List<Lattice> lattices;
    private void Update()
    {
        if (lattices[0].GetObjectSO().name == "A1" && lattices[1].GetObjectSO().name == "A2" && lattices[2].GetObjectSO().name == "A3")
        {
            foreach (var lattice in lattices)
                lattice.ClearObject();
            Lock_manager.instance.Unlock(true, -1, 1);
        }
        else if (lattices[0].GetObjectSO().name == "B1" && lattices[1].GetObjectSO().name == "B2" && lattices[2].GetObjectSO().name == "B3")
        {
            foreach (var lattice in lattices)
                lattice.ClearObject();
            Lock_manager.instance.Unlock(true, -1, 2);

        }
        else if (lattices[0].GetObjectSO().name == "C1" && lattices[1].GetObjectSO().name == "C2" && lattices[2].GetObjectSO().name == "C3")
        {
            foreach (var lattice in lattices)
                lattice.ClearObject();
            Lock_manager.instance.Unlock(true, -1, 3);

        }
        else if (lattices[0].GetObjectSO().name == "D1" && lattices[1].GetObjectSO().name == "D2" && lattices[2].GetObjectSO().name == "D3")
        {
            foreach (var lattice in lattices)
                lattice.ClearObject();
            Lock_manager.instance.Unlock(true, -1, 4);

        }
        else if (lattices[0].GetObjectSO().name == "E1" && lattices[1].GetObjectSO().name == "E2" && lattices[2].GetObjectSO().name == "E3")
        {
            foreach (var lattice in lattices)
                lattice.ClearObject();
            Lock_manager.instance.Unlock(true, -1, 5);

        }
        else if (lattices[0].GetObjectSO().name == "F1" && lattices[1].GetObjectSO().name == "F2" && lattices[2].GetObjectSO().name == "F3")
        {
            foreach (var lattice in lattices)
                lattice.ClearObject();
            Lock_manager.instance.Unlock(true, -1, 6);

        }

    }
}
