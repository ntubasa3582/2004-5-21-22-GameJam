using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _rainObject;
    [SerializeField] private float _interval;

    float _timer;
    private void Start()
    {
        // StartCoroutine(SpawnInterval());
    }

    void Update()
    {
        if(!GameManager.Instance.IsStart) {return;}
        
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _timer = 0;
            Instantiate(_rainObject,transform.position,Quaternion.identity);
        }
    }
    //
    // private IEnumerator SpawnInterval()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(_interval);
    //     }
    // }
}
