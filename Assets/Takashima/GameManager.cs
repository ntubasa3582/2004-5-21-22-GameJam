using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] float _time = 5f;
    [SerializeField] Text _countText;
    [SerializeField] Text _maincountdwun;
    [SerializeField] Text _winText;
    [SerializeField] float _mainutes = 60f;
    float _maintime;
    private bool _isStart = false;
    [SerializeField] Azisai[] _azisai;

    public bool IsStart => _isStart;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCount());
        _countText = GameObject.Find("TimeCountText").GetComponent<Text>();
        _maincountdwun = GameObject.Find("maincounttime").GetComponent<Text>();
        _winText = GameObject.Find("winText").GetComponent<Text>();
        _maintime = _mainutes;
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

        foreach(var azisai in _azisai)
        {
            if (!azisai.IsBlooming) { return; }
            _winText.text = "âJÇÃèüÇø";

        }
        if (_maintime <= 0)
        {
            _winText.text = "ïóÇÃèüÇø";
            _maintime = 0;
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
