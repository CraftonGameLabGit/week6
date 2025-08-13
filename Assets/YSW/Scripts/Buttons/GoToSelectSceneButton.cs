using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToSelectSceneManager : MonoBehaviour
{
    Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        SceneManager.LoadScene("SelectScene_YSH");
    }
}
