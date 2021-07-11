using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TempBlinked : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color animColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    public void Blink()
    {
        Debug.Log("Blink");
        spriteRenderer.DOColor(animColor, 0.4f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
