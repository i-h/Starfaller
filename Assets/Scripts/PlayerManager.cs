using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public static bool IsAlive = true;
    public Sprite Health3;
    public Sprite Health2;
    public Sprite Health3n;
    public Sprite Health2n;
    public Sprite Health1;
    public int BlinkFrameInterval = 4;
    public float BlinkDuration = 1.0f;
    public Transform GameOverScreen;
    static int _lives;
    SpriteRenderer _sr;

    public void Pause()
    {
        StaticPause();
    }
    public static void StaticPause()
    {
        IsPaused = !IsPaused;
        Debug.Log("Pausing");
    }
    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        GameOverScreen.gameObject.SetActive(false);
        IsPaused = false;
        IsAlive = true;
        _lives = 3;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.tag);
        if (c.tag == "Hazard")
        {
            TakeDamage();
            Destroy(c.gameObject);
            SoundManager.PlaySound(SoundManager.Instance.BadGemSound);
        } else if (c.tag == "GoodGem")
        {
            Handheld.Vibrate();
            GoodGem g = c.GetComponent<GoodGem>();
            ScoreManager.AddGem(g);
            Destroy(c.gameObject);
            SoundManager.PlaySound(SoundManager.Instance.GoodGemSound);
        }
    }

    void TakeDamage()
    {
        _lives--;
        Handheld.Vibrate();
        Handheld.Vibrate();
        switch (_lives)
        {
            case 3:
                // Everything good :)
                break;
            case 2:
                StartCoroutine(Blink(Health3n, Health2));
                break;
            case 1:
                StartCoroutine(Blink(Health2n, Health1));
                break;
            default:
                Die();
                break;
        }
    }

    IEnumerator Blink(Sprite blinkSprite, Sprite nextSprite)
    {
        Sprite orig = _sr.sprite;
        float startTime = Time.time;
        int blinkFrames = BlinkFrameInterval;
        bool blinkSwitch = false;
        while (Time.time - startTime < BlinkDuration)
        {
            if (blinkFrames <= 0)
            {
                _sr.sprite = blinkSwitch ? orig : blinkSprite;
                blinkSwitch = !blinkSwitch;
                blinkFrames = BlinkFrameInterval;
            }

            blinkFrames--;
            yield return new WaitForEndOfFrame();
        }
        _sr.sprite = nextSprite;
    }

    private void Die()
    {
        StaticPause();
        GameOverScreen.gameObject.SetActive(true);
        ScoreManager.Instance.ShowEndScreen();
        //SoundManager.PlaySound(SoundManager.Instance.DeathSound);
    }
}
