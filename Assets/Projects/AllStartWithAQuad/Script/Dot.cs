using mj.gist;
using System.Collections;
using UnityEngine;


public class Dot : MonoBehaviour
{
    [SerializeField] private Vector2 lifeTime = new Vector2(1f, 3f);
    [SerializeField] private Vector2 size = new Vector2(0.5f, 1.5f);
    private Block block;
    void Start()
    {
        block = new Block(GetComponent<Renderer>());
        transform.localScale = Vector3.one * size.GetRandom();
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        yield return null;
        block.SetFloat("_Seed", Random.value);

        var life = lifeTime.GetRandom();
        var t = 0f;
        while (t < life)
        {
            t += Time.deltaTime;
            block.SetFloat("_Age", t / life);
            block.Apply();

            yield return null;
        }

        DestroyImmediate(gameObject);
    }
}
