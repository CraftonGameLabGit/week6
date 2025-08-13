using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour
{
    Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        SceneChangeManager.SceneID++;
        Debug.Log(SceneChangeManager.SceneID);
        SceneChangeManager.ButtonClick.RightButtonClick(SceneChangeManager.SceneID);
        StartCoroutine(ButtonInterActive());
    }

    IEnumerator ButtonInterActive()
    {
        _button.interactable = false;
        yield return new WaitForSeconds(0.5f);
        _button.interactable = true;
    }

   
}
