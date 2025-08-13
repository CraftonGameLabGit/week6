using System;
using System.Threading;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    // Singleton
    public static OceanManager Instance => _instance;
    private static OceanManager _instance;

    public bool OceanClear => oceanClear;
    private bool oceanClear = false;
    public Sprite[] Fishes => fishes;
    private Sprite[] fishes;
    public GameObject FishPrefab => fishPrefab;
    private GameObject fishPrefab;
    public GameObject Whirl => whirl;
    private GameObject whirl;
    public OceanInfomation OceanInfo => oceanInfo;
    private OceanInfomation oceanInfo = new OceanInfomation();

    private InfoScore fishScore;
    private InfoTime fishTime;

    public event Action OnFinishEvent;

    [SerializeField] private AudioClip fishScoreUpSound; // 물고기 스코어 증가 효과음
    private AudioSource audioSource; // 사운드 재생용 컴포넌트



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        Init();
    }

    private void Start()
    {
        // AudioSource 초기화
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    //initial setting
    private void Init()
    {
        fishes = Resources.LoadAll<Sprite>("SDH/FishOrigin");
        fishPrefab = Resources.Load<GameObject>("SDH/Fish");
        whirl = Resources.Load<GameObject>("SDH/Whirl");

        fishScore = FindAnyObjectByType<InfoScore>();
        fishTime = FindAnyObjectByType<InfoTime>();

        Application.targetFrameRate = 61;
        Physics2D.gravity = new Vector2(0, -2);
    }

    public void RenewFishScore()
    {
        fishScore.RenewFishScore();
    }

    public void GameClear()
    {
        if (!oceanClear)
        {
            oceanClear = true;
            OnFinishEvent?.Invoke();
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
    }

    public void PlayFishScoreSound(bool isIncreasing)
    {
        if (isIncreasing && fishScoreUpSound != null)
        {
            audioSource.PlayOneShot(fishScoreUpSound);
        }
        
    }
}
