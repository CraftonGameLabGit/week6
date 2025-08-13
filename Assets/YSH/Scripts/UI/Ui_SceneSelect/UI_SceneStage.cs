using System.Collections;
using UnityEngine;

/// <summary>
/// Scene ���� ������ �ʹ� ������ �Ǿ ��ư�� �ѹ����� ������ ���Ƴ��ߵ� 
/// </summary>
public class UI_SceneStage : MonoBehaviour
{
    public int stageID; // Stage �Ǻ� ���� ����
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
        if (stageID == ID) // �ش� ���� ��� ���ٴ� �Ű� animation ���� 
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
