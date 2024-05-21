using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Azisai : MonoBehaviour
{
    [SerializeField] private int _bloomCount;
    [SerializeField] private Sprite[] _azisaiImages = new Sprite[9];

    private int _count;
    private bool _isBlooming;
    private SpriteRenderer _renderer;

    public bool IsBlooming => _isBlooming;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isBlooming) { return; }

        if (collision.gameObject.CompareTag("Rain"))
        {
            _count++;
            if (_count >= _bloomCount)
            {
                Debug.Log("çÁÇ¢ÇΩ");
                _renderer.sprite = _azisaiImages[Random.Range(0,_azisaiImages.Length)] ;
                _isBlooming = true;
            }
        }
        else
        {
            Debug.Log("ame");
        }

    }
}
