using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] _audios;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] int _soundCount;
    [SerializeField] float _soundVolume;
    [SerializeField] float _clickInterval;
    void Start()
    {
        _audioSource.volume = _soundVolume;
    }
    
    void Update()
    {
        
    }

    public void ClickAudioPlay(string _sceneName)
    {
        StartCoroutine(PlayAudio(_clickInterval,_soundCount,_sceneName));
    }

    IEnumerator PlayAudio(float _interval, int _clipCount,string name)
    {
        _audioSource.PlayOneShot(_audios[0]);
        yield return new WaitForSeconds(_interval);
        SceneManager.LoadScene(name);

    }
}
