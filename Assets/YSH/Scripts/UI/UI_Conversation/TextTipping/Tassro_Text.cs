using TMPro;
using UnityEngine;

public class Tassro_Text : MonoBehaviour
{
    TMP_Text _tassroText;
    void Start()
    {
        _tassroText = GetComponent<TMP_Text>();
        SceneChangeManager.ButtonClick.OnSceneStartConversationEvent += TassroTextChange;
    }

    void TassroTextChange(int stageID)
    {
        _tassroText.text = TalkDataBase.CharTalkDataBase[stageID].Character2_Talk1;
    }

  
}
