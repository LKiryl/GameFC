using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Fade : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 1.5f;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _respawnPoint;

    private Image _image;
    private CinemachineVirtualCamera _virtualCamera;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _virtualCamera = FindFirstObjectByType<CinemachineVirtualCamera>();
    }

    public void FadeInAndOut()
    {
        StartCoroutine(FadeIn());
    }
    private IEnumerator FadeIn()
    {
        yield return StartCoroutine(FadeRoutine(1f));
        RespawnPlayer();
        StartCoroutine(FadeRoutine(0f));
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        float elapsedTime = 0f;
        float startValue = _image.color.a;

        while(elapsedTime < _fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetAlpha, elapsedTime / _fadeTime);
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, newAlpha);
            yield return null;
        }

        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, targetAlpha);
        
    }

    private void RespawnPlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _respawnPoint.position, Quaternion.identity);
        _virtualCamera.Follow = player.transform;       

    }
}
