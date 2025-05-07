using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject directoryUI;
    private void Start()
    {
        Lock_manager.instance.Unlock(true, 1, 1);
        Lock_manager.instance.Unlock(false, 1, 1);
    }
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
