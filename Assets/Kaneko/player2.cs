using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]

public class player2: MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    bool Stanfalse=true;
    float _time;
    [SerializeField] float _Stantime=3f;
    Rigidbody2D _rb;
    Vector2 _moveVector;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Stanfalse==true)
        {
            //Vector2 position = transform.position;
            //    {
            //        if (Input.GetKey("a"))
            //        {
            //            position.x -= _speed;
            //        }
            //        else if (Input.GetKey("d"))
            //        {
            //            position.x += _speed;
            //        }
            //        else if (Input.GetKey("w"))
            //        {
            //            position.y += _speed;
            //        }
            //        else if (Input.GetKey("s"))
            //        {
            //            position.y -= _speed;
            //        }

            //        transform.position = position;
            //    }
            _moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _rb.velocity = _moveVector * _speed;

        }
        else if(Stanfalse==false) 
        {
            _time += Time.deltaTime;
            if (_time >= _Stantime)
            {
                Stanfalse = true;
                _time = 0;
            }
        }
    }
    
}
