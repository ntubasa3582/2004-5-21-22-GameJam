using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _rainObject;
    [SerializeField] private float _interval;

    private void Start()
    {
        StartCoroutine(SpawnInterval());
    }
    private IEnumerator SpawnInterval()
    {
        while (true)
        {
            Instantiate(_rainObject,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(_interval);
        }
    }
}
