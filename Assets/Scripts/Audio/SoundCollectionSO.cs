using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SoundCollectionSO : ScriptableObject
{
    [Header("Music")]
    public SoundSO[] FightMusic;
    public SoundSO[] DiscoMusic;


    [Header("SFX")]
    public SoundSO[] GunShoot;
    public SoundSO[] Jump;
    public SoundSO[] Splat;
    public SoundSO[] Jetpack;
    public SoundSO[] GrenadeShoot;
    public SoundSO[] GrenadeExplode;
    public SoundSO[] GrenadeBeep;
    public SoundSO[] PlayerHit;
}
