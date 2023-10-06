using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] float _realTime;
    [SerializeField] float _nightFog;
    [SerializeField] float _nightFogCalc;
    [SerializeField] Animator _beingNight;
    float _dayFog;
    float _currentFogDensity;
    public bool _isNight = false;

    void Start()
    {
        _dayFog = RenderSettings.fogDensity;
        RenderSettings.fogDensity = 1f;
    }
    void Update()
    {
        transform.Rotate(Vector3.right,0.1f*_realTime*Time.deltaTime);

        if (transform.eulerAngles.x >= 170)
        {
            _isNight = true;
            _beingNight.SetBool("IsNight", true);
        }
        else if(transform.eulerAngles.x <= 10)
        {
            _isNight = false;
            _beingNight.SetBool("IsNight", false);
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
