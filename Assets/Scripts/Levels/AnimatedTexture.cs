using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    public Material textureToScroll;
    public float scrollingSpeedX;
    public float scrollingSpeedY;


    private void Update()
    {
        textureToScroll.mainTextureOffset = new Vector2(textureToScroll.mainTextureOffset.x + (scrollingSpeedX * Time.deltaTime), textureToScroll.mainTextureOffset.y + (scrollingSpeedY * Time.deltaTime));
    }
}
