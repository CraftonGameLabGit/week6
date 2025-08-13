using TMPro;
using UnityEngine;

/// <summary>
/// �ִϸ��̼� ���鶧 ������ ���� ������ �ȵ� ���� �ϴ� �� ���� 
/// UI�� �ϳ� �� ����°� �����ٰ� �Ǵ� 
/// </summary>
public class Woman_Text : MonoBehaviour
{
    TMP_Text _womanText;

    void Start()
    {
        _womanText = GetComponent<TMP_Text>();
        SceneChangeManager.ButtonClick.OnSceneStartConversationEvent += WomanTextChange;
    }
    void WomanTextChange(int stageID)
    {
        Debug.Log(_womanText.text);
        _womanText.text = TalkDataBase.CharTalkDataBase[stageID].Character1_Talk1;
    }
}
