using System.Collections;
using UnityEngine;

/// <summary>
/// Scene 들어가고 나갈때 너무 빠르게 되어서 버튼을 한번씩만 눌리게 막아놔야됨 
/// </summary>
public class UI_SceneStage : MonoBehaviour
{
    public int stageID; // Stage 판별 해줄 변수
    Canvas _canvas;
    Animator _sceneStageAni;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _sceneStageAni = GetComponentInChildren<Animator>();
        SceneChangeManager.ButtonClick.OnRightButtonClickEvent += SceneChangeEvent;
        SceneChangeManager.ButtonClick.OnLeftButtonClickEvent += SceneChangeEvent;
    }

    void SceneChangeEvent(int ID)
    {
        if (stageID == ID) // 해당 씬이 골라 졌다는 거고 animation 실행 
        {
            if (!_canvas.enabled)
            {
                _canvas.enabled = true;
                _sceneStageAni.Play("StageSelect");
            }
        }
        else
        {
            if (_canvas.enabled)
            {
                _sceneStageAni.Play("StageUnSelect");
                StartCoroutine(CanvasEnabled());
            }
        }
    }

    IEnumerator CanvasEnabled()
    {
        yield return new WaitForSeconds(0.5f);
        _canvas.enabled = false;
    }
    
}
