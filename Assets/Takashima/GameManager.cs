using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance = default;
    public static GameManager Instance => instance;
    SceneScript _sceneScript;
    [SerializeField] Text _countText;
    [SerializeField] Text _maincountdwun;
    //Text _winText;
    [SerializeField,Header("制限時間")] float _mainutes = 60f;
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

        _sceneScript = GameObject.FindAnyObjectByType<SceneScript>();
    }

    void Start()
    {
        StartCoroutine(StartCount());
        _countText = GameObject.Find("TimeCountText").GetComponent<Text>();
        _maincountdwun = GameObject.Find("maincounttime").GetComponent<Text>();
        //_winText = GameObject.Find("winText").GetComponent<Text>();
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
        
        if (_maintime < 0.5f)
        {
            //_winText.text = "風の勝ち";
            _sceneScript.ChangeScene("Wind");
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
                //_winText.text = "雨の勝ち";
                _sceneScript.ChangeScene("RainWin");
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