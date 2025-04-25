using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text contexlText;
    [SerializeField] private float time = 0.5f;
    public bool isDialog = false;
    private string[] dialogs;
    private int index;
    private void Start()
    {
        parent.SetActive(false);
        index = 0;
        isDialog = false;
    }
    private void Update()
    {
        
    }

    public void UpdateDialog()
    {
        if (!(parent.activeSelf == true && isDialog == false))
            return;
        if (index == dialogs.Length)
        {
            Hide();
            return;
        }
        string[] dialog = dialogs[index].Split('£º');
        nameText.text = dialog[0]+':';
        contexlText.text = null;
        StartCoroutine(Printer(dialog[1]));
        index++;
    }

    public void Show()
    { 
        index = 1;
        parent.SetActive(true);
        UpdateDialog();
    }
    public void Hide()
    { 
        parent.SetActive(false);
    }
    public void SetText(TextAsset text)
    {         
        dialogs = text.text.Split("\n");
    }
    IEnumerator Printer(string str)
    { 
        isDialog = true;
        for(int i = 0; i < str.Length; i++) 
        { 
            contexlText.text += str[i];
            yield return new WaitForSeconds(time);
        }
        isDialog = false;
    }
}
