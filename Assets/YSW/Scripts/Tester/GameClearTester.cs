using UnityEngine;

public class GameClearTester : MonoBehaviour
{
    [SerializeField]
    private float GoalScore = 10;
    private bool isGameCleared = false; // 게임 클리어 여부 플래그


    private void Start()
    {
        isGameCleared = false;
    }

    void Update()
    {
        // 이미 클리어했으면 더 이상 체크하지 않음
        if (isGameCleared) return;

        // 갯수 가져오는거 어디 있어? // 숲이랑 도시 두개는 됨 
        if (GoalLine_forest.score >= GoalScore || GoalLine_City.score >= GoalScore)
        {
            Managers.GameClearEvent.GameClear();
            isGameCleared = true; // 클리어 상태로 설정
        }
    }
}
