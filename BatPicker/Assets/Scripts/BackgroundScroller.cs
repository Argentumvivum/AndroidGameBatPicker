using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    //scrolling background speed
    public float scrollSpeed;

    //default background offset value
    private Vector2 savedOffset;

    //stores current background offset value
    private Vector2 offset;

    private MeshRenderer render;
    private float x;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
        savedOffset = render.sharedMaterial.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        offset = new Vector2(x, savedOffset.y);
        render.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    private void OnDisable()
    {
        render.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}