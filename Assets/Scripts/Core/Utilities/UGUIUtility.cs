using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGUIUtility
{
    public static void AlignAnchorAndPivot(SpriteAlignment alignment, ref RectTransform rect)
    {
        switch (alignment)
        {
            case SpriteAlignment.Center:
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.anchorMax = new Vector2(0.5f, 0.5f);
                rect.anchorMin = new Vector2(0.5f, 0.5f);
                break;
            case SpriteAlignment.TopLeft:
                rect.pivot = new Vector2(0f, 1f);
                rect.anchorMax = new Vector2(0f, 1f);
                rect.anchorMin = new Vector2(0f, 1f);
                break;
            case SpriteAlignment.TopCenter:
                rect.pivot = new Vector2(0.5f, 1f);
                rect.anchorMax = new Vector2(0.5f, 1f);
                rect.anchorMin = new Vector2(0.5f, 1f);
                break;
            case SpriteAlignment.TopRight:
                rect.pivot = new Vector2(1f, 1f);
                rect.anchorMax = new Vector2(1f, 1f);
                rect.anchorMin = new Vector2(1f, 1f);
                break;
            case SpriteAlignment.LeftCenter:
                rect.pivot = new Vector2(0f, 0.5f);
                rect.anchorMax = new Vector2(0f, 0.5f);
                rect.anchorMin = new Vector2(0f, 0.5f);
                break;
            case SpriteAlignment.RightCenter:
                rect.pivot = new Vector2(1f, 0.5f);
                rect.anchorMax = new Vector2(1f, 0.5f);
                rect.anchorMin = new Vector2(1f, 0.5f);
                break;
            case SpriteAlignment.BottomLeft:
                rect.pivot = new Vector2(0f, 0f);
                rect.anchorMax = new Vector2(0f, 0f);
                rect.anchorMin = new Vector2(0f, 0f);
                break;
            case SpriteAlignment.BottomCenter:
                rect.pivot = new Vector2(0.5f, 0f);
                rect.anchorMax = new Vector2(0.5f, 0f);
                rect.anchorMin = new Vector2(0.5f, 0f);
                break;
            case SpriteAlignment.BottomRight:
                rect.pivot = new Vector2(0f, 1f);
                rect.anchorMax = new Vector2(0f, 1f);
                rect.anchorMin = new Vector2(0f, 1f);
                break;
            case SpriteAlignment.Custom:
                break;
            default:
                break;
        }
    }
    public static void Reset(ref RectTransform rect)
    {
        AlignAnchorAndPivot(SpriteAlignment.Center, ref rect);
        rect.localScale = Vector3.one;
        rect.localRotation = Quaternion.identity;
        rect.localPosition = Vector3.zero;
    }
}
