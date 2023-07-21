using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] float _realTime;
    [SerializeField] float _nightFog;
    [SerializeField] float _nightFogCalc;
    float _dayFog;
    float _currentFogDensity;

    bool _isNight = false;


    // Start is called before the first frame update
    void Start()
    {
        _dayFog = RenderSettings.fogDensity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right,0.1f*_realTime*Time.deltaTime);

        if (transform.eulerAngles.x >= 170)
        {
            _isNight = true;
        }
        else if(transform.eulerAngles.x <= 10)
        {
            _isNight = false;
        }

        if(_isNight)
        {
            if(_currentFogDensity <= _nightFog)
            {
                _currentFogDensity += 0.1f * _nightFogCalc * Time.deltaTime;
                RenderSettings.fogDensity = _currentFogDensity; 
            }
        }
        else
        {
            if (_currentFogDensity >= _dayFog)
            {
                _currentFogDensity -= 0.1f * _nightFogCalc * Time.deltaTime;
                RenderSettings.fogDensity = _currentFogDensity;
            }
        }
    }
}
