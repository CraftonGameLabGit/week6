using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirl : MonoBehaviour
{
    private CircleCollider2D circleCollider2;
    private ContactFilter2D filter;

    private void Awake()
    {
        circleCollider2 = GetComponent<CircleCollider2D>();

        filter.SetLayerMask(~(1 << LayerMask.NameToLayer("Box") | 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("HardGround")));
    }

    private void Start()
    {
        StartCoroutine(WhirlLifeCycle());
    }

    private void Update()
    {
        Wiggle();
        Spin();
    }

    private void Wiggle()
    {
        List<Collider2D> result = new();
        circleCollider2.Overlap(filter, result);

        foreach(var elem in result)
        {
            elem.attachedRigidbody.AddForce(((Vector2)transform.position - elem.attachedRigidbody.position).normalized * 15f, ForceMode2D.Impulse);
            if (Vector2.Distance(elem.attachedRigidbody.position, transform.position) < 0.5f)
            {
                elem.attachedRigidbody.AddForce(new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)).normalized * 25f, ForceMode2D.Impulse);
            }
        }
    }

    private void Spin()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 6);
    }

    private IEnumerator WhirlLifeCycle()
    {
        float t = 0f;

        while (t < 5f)
        {
            transform.localScale = new(t / 1.5f, t / 1.5f, 1);
            t += Time.deltaTime;

            yield return null;
        }

        WhirlDeathRattle();

        Destroy(gameObject);

        yield break;
    }


    private void WhirlDeathRattle()
    {
        List<Collider2D> result = new();
        circleCollider2.Overlap(filter, result);
        Vector2 outForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 30f;

        foreach (var elem in result)
        {
            elem.attachedRigidbody.AddForce(outForce, ForceMode2D.Impulse);
        }
    }
}
