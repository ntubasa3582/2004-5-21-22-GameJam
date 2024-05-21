using UnityEngine;
using UnityEngine.Serialization;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _arrowPrefab;

    [SerializeField, Tooltip("プレイヤー１のバレットインターバル")]
    float _bulletInterval = 0.5f;

    float _timer;
    bool _isClick;
    Vector2 _mousePos;
    Vector2 _mouseDown;
    Vector2 _mouseUp;
    Vector2 _vector;
    Vector2 _arrowVector;
    Vector2 _arrowVectorStorage;

    void Update()
    {
        if (GameManager.Instance.IsStart)
        {
            if (!_isClick)
            {
                _mousePos = Input.mousePosition;
                _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);

                _arrowVector = _mousePos - _mouseDown;
                float angle = Mathf.Atan2(_arrowVector.y * -1, _arrowVector.x * -1) * Mathf.Rad2Deg - 90f;


                if (Input.GetMouseButtonDown(0))
                {
                    _mouseDown = _mousePos;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    _mouseUp = _mousePos;

                    _vector = _mouseDown - _mouseUp;
                    GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(_vector, ForceMode2D.Impulse);
                    _arrowPrefab.transform.localScale = new Vector3(1, 1, 1);
                    _isClick = true;
                }

                if (Input.GetMouseButton(0))
                {
                    float distance = Vector2.Distance(_mouseDown, _mousePos);
                    if (distance >= 3)
                    {
                        _arrowPrefab.transform.localScale = new Vector3(1, 4, 1);
                    }
                    else
                    {
                        _arrowPrefab.transform.localScale = new Vector3(1, distance + 1, 1);
                    }

                    _arrowPrefab.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }


            if (_isClick)
            {
                _timer += Time.deltaTime;
                if (_timer > _bulletInterval)
                {
                    _timer = 0;
                    _isClick = false;
                }
            }
        }
    }
}