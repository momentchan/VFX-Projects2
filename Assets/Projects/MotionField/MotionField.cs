using System.Collections;
using mj.gist;
using mj.gist.tracking;
using Unity.VisualScripting;
using UnityEngine;
using static mj.gist.MaskGenerator;
using UnityEngine.UI;

public class MotionField : MonoBehaviour
{
    PingPongRenderTexture renderTexture;
    PingPongRenderTexture renderTexture2;
    [SerializeField] private Material mat;
    [SerializeField] private float delay = 0.1f;
    [SerializeField] private RenderTexture preTex;
    [SerializeField] private RenderTexture diffTex;
    [SerializeField] private ImageSource source;

    [SerializeField] Material composite;
    [SerializeField] private RenderTexture output;

    private void Start()
    {
        renderTexture = new PingPongRenderTexture(preTex);
        renderTexture2 = new PingPongRenderTexture(preTex);
        StartCoroutine(Capture());
    }
    IEnumerator Capture()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Graphics.Blit(source.Texture, renderTexture.Write);
            Graphics.Blit(renderTexture.Read, preTex);
            renderTexture.Swap();
        }
    }
    private void Update()
    {
        composite.SetTexture("_Composite", renderTexture2.Read);
        composite.SetTexture("_Diff", diffTex);

        Graphics.Blit(Texture2D.blackTexture, renderTexture2.Write, composite);
        renderTexture2.Swap();

        Graphics.Blit(renderTexture2.Read, output);
    }

    private void OnDestroy()
    {
        renderTexture.Dispose();
    }
}
