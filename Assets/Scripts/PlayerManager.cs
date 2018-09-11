using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static bool IsAlive = true;
    static int _lives;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Hazard>() != null)
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        _lives--;
        switch (_lives)
        {
            case 3:

                break;
            case 2:

                break;
            case 1:

                break;
            case 0:

                break;
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}
