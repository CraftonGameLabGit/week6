using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public enum eFishState{
    Free, // 자유 움직임
    Run, // 플레이어로부터 도망
    Afraid, // 상어로부터 도망
    Catch, // 손에 잡힘
    Feed // 상어에게 먹힘
};

public class Fish : MonoBehaviour
{
    private Transform leftHand, rightHand, pan;
    private Transform shark;
    private Rigidbody2D rigidbody2;
    private CircleCollider2D sharkCollider;

    private IEnumerator move;

    private float fishSpeed;
    private eFishState fishState = eFishState.Free;
    int dir = 1, timer = 100, timerMax = 0;

    private void Awake()
    {
        leftHand = FindAnyObjectByType<DroneController>().transform.GetChild(0).GetChild(0);
        rightHand = FindAnyObjectByType<DroneController>().transform.GetChild(0).GetChild(1);
        pan = FindAnyObjectByType<FaceChanger>().transform;
        shark = FindAnyObjectByType<Shark>().transform;

        rigidbody2 = GetComponent<Rigidbody2D>();
        sharkCollider = shark.GetComponent<CircleCollider2D>();

        fishSpeed = Random.Range(1f, 2.5f);
    }

    private void Start()
    {
        SetFishSprite();

        //StartCoroutine(move = Move());
        //StartCoroutine(Feed());
    }

    private void Update()
    {
        fishState = SetFishState(fishState);
        ActFish();
    }

    private void ActFish()
    {
        switch (fishState)
        {
            case eFishState.Free:
                Move();
                break;
            case eFishState.Run:
                Run();
                break;
            case eFishState.Afraid:
                Flee();
                break;
        }

        timer++;
    }

    private void Move()
    {
        if (timer > timerMax)
        {
            timer = 0;
            timerMax = Random.Range(50, 200);
            dir = Random.Range(0, 2) == 0 ? Random.Range(-7, -3) : Random.Range(3, 7);
        }

        rigidbody2.position += Vector2.right * 0.1f * fishSpeed / dir;

        if (dir < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);

        //timer++;
    }

    private void Run()
    {
        Vector2 fishVector = rigidbody2.position - (Vector2)pan.position;

        //rigidbody2.linearVelocity = fishVector.normalized * 30f / fishVector.magnitude;
        //rigidbody2.MovePosition(rigidbody2.position + fishVector.normalized * 0.5f / fishVector.magnitude);
        //dir = (int)fishVector.x;
        rigidbody2.position += fishVector.normalized * fishSpeed / (Mathf.Pow(fishVector.magnitude, 1.5f));

        if (fishVector.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Flee()
    {
        rigidbody2.position += Vector2.left * 0.1f;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public IEnumerator Feed()
    {
        rigidbody2.linearVelocity = Vector2.zero;
        Vector3 sharkDelta = new Vector3(15f + Random.Range(-3f, 3f), Random.Range(-3f, 3f));

        while (Vector2.Distance(rigidbody2.position, shark.position + sharkDelta) > 0.3f)
        {
            rigidbody2.position = Vector2.MoveTowards(rigidbody2.position, shark.position + sharkDelta, 0.2f);
            yield return null;
        }

        OceanManager.Instance.OceanInfo.Fish++;
        Destroy(gameObject);

        yield break;
    }

    private void SetFishSprite()
    {
        int x = Random.Range(0, OceanManager.Instance.Fishes.Length);
        GetComponent<SpriteRenderer>().sprite = OceanManager.Instance.Fishes[x];
    }
    
    private eFishState SetFishState(eFishState nowFishState)
    {
        if (nowFishState == eFishState.Feed)
        {
            return eFishState.Feed;
        }
        else if (sharkCollider.OverlapPoint(transform.position))
        {
            rigidbody2.linearVelocity = Vector2.zero;
            GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(Feed());
            return eFishState.Feed;
        }
        else if (nowFishState != eFishState.Catch && rigidbody2.position.x > 15f)
        {
            return eFishState.Afraid;
        }

        float dist = Vector2.Distance(rigidbody2.position, pan.position);

        switch (nowFishState)
        {
            case eFishState.Free:
            case eFishState.Catch:
                if (dist > 12f) return eFishState.Free;
                else if (Vector2.Distance(rigidbody2.position, leftHand.position) < 5f || Vector2.Distance(rigidbody2.position, rightHand.position) < 5f || dist < 5f) return eFishState.Catch;
                else return eFishState.Run;
            case eFishState.Run:
                if (dist > 15f) return eFishState.Free;
                else if (Vector2.Distance(rigidbody2.position, leftHand.position) < 5f || Vector2.Distance(rigidbody2.position, rightHand.position) < 5f || dist < 5f) return eFishState.Catch;
                else return eFishState.Run;
            case eFishState.Afraid:
                if (rigidbody2.position.x > -10f) return eFishState.Afraid;
                else if (dist < 12f) return eFishState.Run;
                else return eFishState.Free;
            default:
                return eFishState.Free;
        }
    }
}
