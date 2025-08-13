using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class WhirlSpawner : MonoBehaviour
{
    private GameObject whirl;
    private Transform pan;

    private void Awake()
    {
        pan = FindAnyObjectByType<FaceChanger>().transform;
    }

    private void Start()
    {
        whirl = OceanManager.Instance.Whirl;

        StartCoroutine(SpawnWhirl());
    }

    private IEnumerator SpawnWhirl()
    {
        while (!OceanManager.Instance.OceanClear)
        {
            yield return new WaitForSeconds(Random.Range(7f, 10f));

            for(int i = 0; i < 2; i++)
            {
                Vector2 whirlPosition = pan.position;

                for(int j=0;j<500;j++)
                {
                    whirlPosition = pan.position + new Vector3(Random.Range(-30f, 30f), Random.Range(-20f, 20f));

                    if (whirlPosition.x > -190f && whirlPosition.x < -20f && whirlPosition.y > -10f && whirlPosition.y < 90f && Vector2.Distance(whirlPosition, pan.position) > 12f)
                    {
                        Instantiate(whirl, whirlPosition, Quaternion.identity);
                        break;
                    }
                }
            }
        }

        yield break;
    }
}
