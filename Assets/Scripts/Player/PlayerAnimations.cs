using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private ParticleSystem _moveDustVFX;
    [SerializeField] private ParticleSystem _poofDustVFX;
    [SerializeField] private float _tiltAngle = 20f;
    [SerializeField] private float _tiltSpeed = 5f;
    [SerializeField] private Transform _characterSpriteTransform;
    [SerializeField] private Transform _cowboyHatSpriteTransform;
    [SerializeField] private float _cowboyHatTiltModifer = 2f;

    private void OnEnable()
    {
        PlayerController.OnJump += PlayPoofDustVFX;
    }

    private void OnDisable()
    {
        PlayerController.OnJump -= PlayPoofDustVFX;
    }
    private void Update()
    {
        DetectMoveDust();
        ApplyTilt();
    }

    private void DetectMoveDust()
    {
        if(PlayerController.Instance.CheckGrounded())
        {
            if(!_moveDustVFX.isPlaying)
            {
                _moveDustVFX.Play();
            }
        }
        else
        {
            if (_moveDustVFX.isPlaying)
            {
                _moveDustVFX.Stop();
            }
        }
    }

    private void PlayPoofDustVFX()
    {
        _poofDustVFX.Play();
    }

    private void ApplyTilt()
    {
        float targetAngle;

        if(PlayerController.Instance.MoveInput.x < 0f)
        {
            targetAngle = _tiltAngle;
        }else if(PlayerController.Instance.MoveInput.x > 0f)
        {
            targetAngle = -_tiltAngle;
        }
        else
        {
            targetAngle = 0f;
        }

        Quaternion currentCharacterRotation = _characterSpriteTransform.rotation;
        Quaternion currentCowboyHatRotation = _cowboyHatSpriteTransform.rotation;
        Quaternion targetCharacterRotation = Quaternion.Euler(currentCharacterRotation.eulerAngles.x,
            currentCharacterRotation.eulerAngles.y, targetAngle);
        Quaternion targetCowboyHatRotation = Quaternion.Euler(currentCowboyHatRotation.eulerAngles.x,
            currentCowboyHatRotation.eulerAngles.y, -targetAngle / _cowboyHatTiltModifer);

        _characterSpriteTransform.rotation = Quaternion.Lerp(currentCharacterRotation, targetCharacterRotation,
            _tiltSpeed * Time.deltaTime);
        _cowboyHatSpriteTransform.rotation = Quaternion.Lerp(currentCowboyHatRotation, targetCowboyHatRotation,
            _tiltSpeed * _cowboyHatTiltModifer * Time.deltaTime);
    }
}
