using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontroller : MonoBehaviour
{
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > 3)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
        }
    }
}