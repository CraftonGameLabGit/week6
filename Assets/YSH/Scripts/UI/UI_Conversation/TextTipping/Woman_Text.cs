using TMPro;
using UnityEngine;

/// <summary>
/// 애니메이션 만들때 꺼지게 만들어서 적용이 안됨 수정 하는 거 보다 
/// UI를 하나 더 만드는게 빠르다고 판단 
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
