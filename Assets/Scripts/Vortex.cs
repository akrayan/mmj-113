using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField] float _maxRotationSpeed = 200;
    [SerializeField] float _maxForce = 5;
    float _rotationSpeed = 0;
    float _force = 0;
    float _power = 1;
    Vector3 _originalScale;
    bool _isClockWise = true;

    void Start()
    {
        _originalScale = transform.localScale;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _power += 0.1f;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _power -= 0.1f;
        _power = Mathf.Clamp(_power, -1, 1);
        _force = _maxForce * Mathf.Abs(_power);
        _rotationSpeed = _maxRotationSpeed * _power;
        _isClockWise = _power >= 0;
        UpdateSprite();
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("should attract " + other.name);
        IAttractable attractable = other.GetComponent<IAttractable>();
        if (attractable is not null)
            Attract(attractable, other.transform.position);
    }

    void UpdateSprite()
    {
        Vector3 scale = _originalScale;
        scale.x *= _isClockWise ? 1 : -1;
        transform.localScale = scale;
        transform.Rotate(Vector3.back * _rotationSpeed * Time.deltaTime);
    }

    void Attract(IAttractable other, Vector3 position)
    {
        Vector3 attraction = transform.position - position;
        attraction.Normalize();
        Vector2 normal = Vector2.Perpendicular((new Vector2(attraction.x, attraction.z)));
        if (_isClockWise) normal *= new Vector2(-1, -1);
        attraction.x -= normal.x / 2;
        attraction.z -= normal.y / 2;
        attraction *= _force;
        other.UpdateAttraction(attraction);
    }


}
