using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    private BoxCollider2D[] boxCollider2s;
    private ContactFilter2D filter;
    private GameObject fish;
    private Transform pan;

    private void Awake()
    {
        boxCollider2s = GetComponentsInChildren<BoxCollider2D>();
        pan = FindAnyObjectByType<FaceChanger>().transform;

        filter.SetLayerMask(1 << LayerMask.NameToLayer("Box"));
    }

    private void Start()
    {
        fish = OceanManager.Instance.FishPrefab;

        foreach(var elem in boxCollider2s)
        {
            for (int i = 0; i < OceanManager.Instance.OceanInfo.FishMax / 6; i++) // 원래 6이었음
            {
                GameObject newFish = Instantiate(fish, new Vector2(UnityEngine.Random.Range(elem.bounds.min.x, elem.bounds.max.x), UnityEngine.Random.Range(elem.bounds.min.y, elem.bounds.max.y)), Quaternion.identity);
            }
        }

        StartCoroutine(InputFish());

        /*for(int i = 0; i < OceanManager.Instance.OceanInfo.FishMax * 2f; i++)
        {
            GameObject newFish = Instantiate(fish);
            newFish.transform.position = new Vector2(Random.Range(-199f, -17f), Random.Range(-13f, 97f));
        }*/
    }

    private IEnumerator InputFish()
    {
        while (!OceanManager.Instance.OceanClear)
        {
            int caughtFishes = OceanManager.Instance.OceanInfo.Fish;

            yield return new WaitForSeconds(15f);

            caughtFishes = OceanManager.Instance.OceanInfo.Fish - caughtFishes;

            int[] nowFishes = new int[9];

            for(int i = 0; i < 9; i++)
            {
                List<Collider2D> result = new();
                boxCollider2s[i].Overlap(filter, result);
                nowFishes[i] = result.Count;
            }

            int[] sortFishes = new int[9];
            Array.Copy(nowFishes, sortFishes, 9);
            Array.Sort(sortFishes);

            int[] rank = new int[9];

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (nowFishes[i] == sortFishes[j]) rank[j] = i;
                }
            }

            for(int i = 0; i < 9; i++)
            {
                for(int j = caughtFishes; j > 0; j--)
                {
                    Vector2 newPos = new(UnityEngine.Random.Range(boxCollider2s[rank[i]].bounds.min.x, boxCollider2s[rank[i]].bounds.max.x), UnityEngine.Random.Range(boxCollider2s[rank[i]].bounds.min.y, boxCollider2s[rank[i]].bounds.max.y));

                    if(Vector2.Distance(newPos, pan.position) > 70f)
                    {
                        GameObject newFish = Instantiate(fish, newPos, Quaternion.identity);

                        caughtFishes--;
                    }
                }
            }
        }

        yield break;
    }
}
