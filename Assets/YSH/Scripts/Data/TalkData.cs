using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TalkData")]
public class TalkData : ScriptableObject
{
    [TextArea(0, 500)]
    public string Character1_Talk1;
    [TextArea(0, 500)]
    public string Character1_Talk2;
    [TextArea(0, 500)]
    public string Character2_Talk1;
    [TextArea(0, 500)]
    public string Character2_Talk2;
}
