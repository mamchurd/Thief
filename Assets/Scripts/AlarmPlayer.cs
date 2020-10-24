using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]

public class AlarmPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    
    private Coroutine _volumeCorotine;
    private float _maxTime;

    private void Start()
    {
        _maxTime = 10;
    }

    private void Update()
    {
        Debug.Log(_alarm.isPlaying);

        if (_alarm.isPlaying && _alarm.volume == 0 && _volumeCorotine == null)
            _alarm.Stop();
    }

    public void OnTrigerSignaling(float endVolume)
    {
        if (_volumeCorotine != null)
        {
            StopCoroutine(_volumeCorotine);
        }

        float duration = Math.Abs(endVolume - _alarm.volume) * _maxTime;

        _volumeCorotine = StartCoroutine(ChangeVolume(_alarm.volume, endVolume, duration));
    }

    private IEnumerator ChangeVolume(float startVolume, float endVolume, float duration)
    {
        float nextValue;
        float currentTime = 0;
        
        if (!_alarm.isPlaying)
            _alarm.Play();

        while (currentTime < duration)
        {
            nextValue = Mathf.Lerp(startVolume, endVolume, currentTime / duration);
            SetVolume(nextValue);
            currentTime += Time.deltaTime;
            yield return null;
        }

        SetVolume(endVolume);

        _volumeCorotine = null;
    }

    private void SetVolume(float volume)
    {
        _alarm.volume = volume;
    }
}
