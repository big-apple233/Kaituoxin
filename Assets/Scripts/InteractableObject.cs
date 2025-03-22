using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private TextAsset text;
    public TextAsset GetText()
    { 
        return text;
    }
}
