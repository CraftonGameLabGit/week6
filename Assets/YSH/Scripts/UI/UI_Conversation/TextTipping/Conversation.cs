using System.Collections;
using TMPro;
using UnityEngine;

public class Conversation: MonoBehaviour
{
    string _text;
    TMP_Text _targetText;
    const float TEXT_DELAY = 0.075f;

    void Start()
    {
        _targetText = GetComponent<TMP_Text>();
        _text = _targetText.text.ToString();
        _targetText.text = "";

        StartCoroutine(TextPrint(TEXT_DELAY));

        //SceneChangeManager.ButtonClick.OnSceneStartConversationEvent += TextChange;
    }

    //void TextChange(int stageID)
    //{
    //    _text = _targetText.text.ToString();
    //}

    IEnumerator TextPrint(float delay)
    {
        int count = 0;

        while (count != _text.Length)
        {
            if (count < _text.Length)
            {
                _targetText.text += _text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }
    }

}
