using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidedBlock : MonoBehaviour
{
    private SpriteRenderer render;
    public float reTime = 0;
    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Show();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Show();
    }

    private float nowTime = 0;
    // -1 => don't show
    void Show() {
        if (nowTime != -1) {
            render.enabled = true;
            nowTime = reTime;
        }
    }

    void Hide() {
        nowTime -= 0.02f;
        if (nowTime <= 0) {
            nowTime = 0;
            render.enabled = false;
        }
    }

    void FixedUpdate() {
        if (nowTime != 0) {
            Hide();
        }
    }
}
