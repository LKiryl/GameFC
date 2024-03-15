using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DiscoBallManager : MonoBehaviour
{
    public static Action OnDiscoBallHitEvent;

    [SerializeField] private float _discoBallPartyTime = 2f;
    [SerializeField] private float _discoGlobalLightIntensity = .2f;
    [SerializeField] private Light2D _globalLight;

    private Coroutine _dicoCoroutine;
    private ColorSpotlight[] _allSpotlights;
    private float _defaultlGlobalLightIntensity;

    private void Awake()
    {
        _defaultlGlobalLightIntensity = _globalLight.intensity;
    }
    private void Start()
    {
        _allSpotlights = FindObjectsByType<ColorSpotlight>(FindObjectsSortMode.None);
    }
    private void OnEnable()
    {
        OnDiscoBallHitEvent += DimTheLights;
    }

    private void OnDisable()
    {
        OnDiscoBallHitEvent -= DimTheLights;
    }

    public void DiscoBallParty()
    {
        if(_dicoCoroutine != null) { return; }

        OnDiscoBallHitEvent?.Invoke();
    }
    private void DimTheLights()
    {
        foreach (ColorSpotlight light in _allSpotlights)
        {
            StartCoroutine(light.SpotLightDiscoParty(_discoBallPartyTime));
        }

        _dicoCoroutine = StartCoroutine(GlobalLightResetRoutine());
    }

    private IEnumerator GlobalLightResetRoutine()
    {        
        _globalLight.intensity = _discoGlobalLightIntensity;

        yield return new WaitForSeconds(_discoBallPartyTime);

        _globalLight.intensity = _defaultlGlobalLightIntensity;
        _dicoCoroutine = null;
    }

    
}
