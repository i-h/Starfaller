using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    public static bool IsAlive = true;
    public Transform Health3;
    public Transform Health2;
    public Transform Health1;
    static int _lives = 3;


    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.tag);
        if (c.tag == "Hazard")
        {
            TakeDamage();
            Destroy(c.gameObject);
        }
    }

    void TakeDamage()
    {
        _lives--;
        switch (_lives)
        {
            case 3:
                // Everything good :)
                break;
            case 2:
                Health3.gameObject.SetActive(false);
                break;
            case 1:
                Health2.gameObject.SetActive(false);
                break;
            default:
                Die();
                break;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
