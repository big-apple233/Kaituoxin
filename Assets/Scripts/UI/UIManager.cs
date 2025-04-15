using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject directoryUI;
    public void ShowDirectoryUI()
    { 
        directoryUI.SetActive(true);
    }
    public void HideDirectoryUI()
    { 
        directoryUI.SetActive(false);
    }

    public void ShowAndHideDirectoryUI()
    {
        directoryUI.SetActive(!directoryUI.activeSelf);
    }
}
