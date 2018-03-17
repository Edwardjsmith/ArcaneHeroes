using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileBrush : MonoBehaviour {

    public Vector2 brushSize = Vector2.zero;
    public int tileID = 0;
    public SpriteRenderer renderer2D;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, brushSize);
    }

    public void updateBrush(Sprite sprite)
    {
        renderer2D.sprite = sprite;
    }
}
