using UnityEngine;

/// <summary>
/// 싱글톤 패턴을 이용한 Managers
/// </summary>
public class Managers : MonoBehaviour
{
    public static Managers Instance => _instance;
    static Managers _instance;

    public static GameClearEvent GameClearEvent => Instance._gameClearEvent;
    GameClearEvent _gameClearEvent = new GameClearEvent();

    private void Awake()
    {
        _instance = this;
    }

}
