using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float _driveSpeed;
    [SerializeField] private float _steerSpeed;
    [SerializeField] private float _slowSpeed;
    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _timeSpeedIsModified;


    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float steerDirection = Input.GetAxis("Horizontal") * _steerSpeed;
        float driveDirection = Input.GetAxis("Vertical") * _driveSpeed;

        transform.Rotate(Vector3.forward * Time.deltaTime * -steerDirection);
        transform.Translate(Vector3.up * Time.deltaTime * driveDirection);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            StartCoroutine(BoostRoutine());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(SlowRoutine());
    }

    IEnumerator BoostRoutine()
    {
        _driveSpeed =+ _boostSpeed;
        yield return new WaitForSeconds(_timeSpeedIsModified);
        _driveSpeed =+ _normalSpeed;
    }
    IEnumerator SlowRoutine()
    {
        StopCoroutine(SlowRoutine());
        _driveSpeed =+ _slowSpeed;
        yield return new WaitForSeconds(_timeSpeedIsModified);
        _driveSpeed =+ _normalSpeed;
    }
}
