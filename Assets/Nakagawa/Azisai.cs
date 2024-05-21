using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azisai : MonoBehaviour
{
    [SerializeField] private int _bloomCount;

    private int _count;
    private bool _isBlooming;

    public bool IsBlooming => _isBlooming;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isBlooming) { return; }

        if (collision.gameObject.CompareTag("Rain"))
        {
            _count++;
            if (_count >= _bloomCount)
            {
                Debug.Log("çÁÇ¢ÇΩ");
                _isBlooming = true;
            }
        }
        else
        {
            Debug.Log("ame");
        }

    }
}
