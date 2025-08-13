using System.Collections.Generic;
using UnityEngine;

public class TalkDataBase : MonoBehaviour
{
    public static Dictionary<int, TalkData> CharTalkDataBase => _charTalkDataBase;
    static Dictionary<int, TalkData> _charTalkDataBase = new Dictionary<int, TalkData>();


    private void Awake()
    {
        AddTalkData(1, "StartStage1");
        AddTalkData(2, "StartStage2");
        AddTalkData(3, "StartStage3");
    }

    void AddTalkData(int stageId , string path)
    {
        if (!_charTalkDataBase.ContainsKey(stageId))
        {
            _charTalkDataBase.Add(stageId, Resources.Load<TalkData>($"YSH/Data/{path}"));
        }
        else
        {
            return;
        }
    }
}
