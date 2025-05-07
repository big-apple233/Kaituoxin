// �ļ�����TMPFontReplacer.cs
using UnityEditor;
using UnityEngine;
using TMPro;

public class TMPFontReplacer : MonoBehaviour
{
    public TMP_FontAsset newFont;

    [MenuItem("Tools/����TMP����")]
    /*public static void ShowWindow()
    {
        GetWindow<TMPFontReplacer>("���������");
    }*/
    private void Awake()
    {
        ReplaceAllFonts();
    }
    /*private void OnGUI()
    {
        GUILayout.Label("��������TextMeshPro����", EditorStyles.boldLabel);

        newFont = (TMP_FontAsset)EditorGUILayout.ObjectField(
            "������",
            newFont,
            typeof(TMP_FontAsset),
            false
        );

        if (GUILayout.Button("��ʼ�滻"))
        {
            ReplaceAllFonts();
        }
    }*/

    private void ReplaceAllFonts()
    {
        if (newFont == null)
        {
            Debug.LogError("����ѡ��Ҫ�滻�������壡");
            return;
        }

        TMP_Text[] allTexts = Resources.FindObjectsOfTypeAll<TMP_Text>();
        int count = 0;

        foreach (TMP_Text text in allTexts)
        {
            // ����Ԥ�����еĶ��������Ҫ����Ԥ������Ƴ�����жϣ�
            if (PrefabUtility.IsPartOfPrefabAsset(text)) continue;

            Undo.RecordObject(text, "Change TMP Font");
            text.font = newFont;
            count++;

            // �����Ҫͬʱ�޸�������ʽ
            // text.fontStyle = FontStyles.Normal;
            // text.color = Color.white;
        }

        Debug.Log($"�ɹ��滻�� {count} ��TextMeshPro���������");
    }
}