using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player2 : MonoBehaviour
{
    [SerializeField] GameObject _rainSpawner;
    [SerializeField] float _speed = 5f;
    bool Stanfalse = true;
    float _time;
    [SerializeField] float _Stantime = 3f;
    Rigidbody2D _rb;

    Vector2 _moveVector;
    SpriteRenderer _renderer;
    [SerializeField] float _alphaTimerCount = 0.3f;
    float _saveTimer;
    bool _isAlpha = false;
    Color _playerColor; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        
        _playerColor = _renderer.color;
        _saveTimer = _alphaTimerCount;
    }

    // Update is called once per frame
    void Update()
    {
        _moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.velocity = _moveVector * _speed;

        if (Stanfalse == false)
        {
            _time += Time.deltaTime;
            if (_time >= _alphaTimerCount)
            {
                if (!_isAlpha)
                {
                    _isAlpha = true;
                    _renderer.color = new Color(_playerColor.r, _playerColor.g, _playerColor.b, 0);
                }
                else
                {
                    _isAlpha = false;
                    _renderer.color = new Color(_playerColor.r, _playerColor.g, _playerColor.b, _playerColor.a);
                }

                _alphaTimerCount += _saveTimer;
            }


            if (_time >= _Stantime)
            {
                Stanfalse = true;
                _rainSpawner.SetActive(true);
                _time = 0;

                _isAlpha = false;
                _alphaTimerCount = _saveTimer;
                _renderer.color = new Color(_playerColor.r, _playerColor.g, _playerColor.b, _playerColor.a);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1Bullet"))
        {
            Stanfalse = false;
            _rainSpawner.SetActive(false);
        }
    }
}