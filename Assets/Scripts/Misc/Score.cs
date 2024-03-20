using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TMP_Text _scoreTMP;
    private int _score = 0;

    private void Awake()
    {
        _scoreTMP = GetComponent<TMP_Text>();
        
    }
   
    private void OnEnable()
    {
        Health.OnDeath += EnemyDestroyed;
    }

    private void OnDisable()
    {
        Health.OnDeath -= EnemyDestroyed;
    }
    private void EnemyDestroyed(Health sender)
    {
        _score++;
        _scoreTMP.text = _score.ToString("D3");
    }
}
