using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    public Material textureToScroll;
    public float scrollingSpeed;


    private void Update()
    {
        textureToScroll.mainTextureOffset = new Vector2(textureToScroll.mainTextureOffset.x + (scrollingSpeed * Time.deltaTime), 1);
    }
}
