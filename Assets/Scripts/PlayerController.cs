using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance { get { return _instance; } }
    public static PlayerController _instance;
    public float MoveSpeed;
    public float MoveFriction = 0.5f;
    public float StopThreshold = 0.1f;
    float _wrapX = 3.5f;
    Vector2 _velocity = new Vector2();
    Vector2 _loopVector = new Vector2();
    Vector3 _scaleVector = Vector3.one;
    public void Awake()
    {
        _instance = this;
    }
    void Update () {
        _loopVector = transform.position;
        if (_loopVector.x < -_wrapX)
        {
            _loopVector.x = _wrapX;
            transform.position = _loopVector;
        } else if (_loopVector.x > _wrapX)
        {
            _loopVector.x = -_wrapX;
            transform.position = _loopVector;
        }

        
        if (_velocity.magnitude == 0)
        {
            // Don't do anything
        }
        else
        {
            MovePlayerObject(_velocity * Time.deltaTime);
            if (_velocity.magnitude < StopThreshold)
            {
                _velocity *= 0;
            }
            else
            {
                _velocity *= MoveFriction;
            }
        }

        if (_velocity.x > 0)
        {
            _scaleVector.x = 1;
        }
        else if (_velocity.x < 0)
        {
            _scaleVector.x = -1;
        }
        transform.localScale = _scaleVector;
    }

    void MovePlayerObject(Vector2 dir)
    {
        transform.Translate(dir);
    }

    public void MovePlayer(Vector2 dir)
    {
        Vector2 moveDir = dir * MoveSpeed;

        _velocity = moveDir;
    }

    public void MoveLeft()
    {
        MovePlayer(Vector2.left);
    }
    public void MoveRight()
    {
        MovePlayer(Vector2.right);
    }

}