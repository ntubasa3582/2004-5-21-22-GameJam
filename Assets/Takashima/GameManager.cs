using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance = default;
    public static GameManager Instance => instance;

    [SerializeField] float _time = 5f;
    [SerializeField] Text _countText;
    [SerializeField] Text _maincountdwun;
    [SerializeField] Text _winText;
    [SerializeField] float _mainutes = 60f;
    float _maintime;
    private bool _isStart = false;
    [SerializeField] Azisai[] _azisai;

    public bool IsStart => _isStart;

    void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<GameManager>();
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(StartCount());
        _countText = GameObject.Find("TimeCountText").GetComponent<Text>();
        _maincountdwun = GameObject.Find("maincounttime").GetComponent<Text>();
        _winText = GameObject.Find("winText").GetComponent<Text>();
        _maintime = _mainutes;
        _isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart == false)
        {
            return;
        }

        _maintime -= Time.deltaTime;
        _maincountdwun.text = _maintime.ToString("N0");

        Debug.Log(_maintime);
        
        if (_maintime < 0.5f)
        {
            _winText.text = "風の勝ち";
            _maintime = 0;
        }

        int count = 0;
        foreach (var azisai in _azisai)
        {
            if (!azisai.IsBlooming)
            {
                return;
            }

            if (azisai.IsBlooming)
            {
                count++;
            }

            if (count >= _azisai.Length)
            {
                _winText.text = "雨の勝ち";
            }
        }
    }

    private IEnumerator StartCount()
    {
        yield return new WaitForSeconds(1);
        _countText.text = "3";
        yield return new WaitForSeconds(1);
        _countText.text = "2";
        yield return new WaitForSeconds(1);
        _countText.text = "1";
        yield return new WaitForSeconds(1);
        _countText.text = "Go";
        yield return new WaitForSeconds(1);
        _countText.gameObject.SetActive(false);
        _isStart = true;
    }
}