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

    }
}
