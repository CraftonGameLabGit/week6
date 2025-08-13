using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager Instance => _instance; 
    static SceneChangeManager _instance;

    public static ButtonClickEvent ButtonClick => Instance._buttonClick;
    ButtonClickEvent _buttonClick = new ButtonClickEvent();

    public static int SceneID
    {
        get
        {
            return Instance._sceneID;
        }
        set
        {
            Instance._sceneID = value;
            Instance.SceneIDRange(Instance._sceneID);
        }
    }
    int _sceneID = 2;

    private void Awake()
    {
        _instance = this;
    }

    void SceneIDRange(int sceneID)
    {
        if (sceneID <= 0)
            SceneID = 3;
        if (sceneID >= 4)
            SceneID = 1;
    }
}
