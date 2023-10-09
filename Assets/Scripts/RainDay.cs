using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDay : MonoBehaviour
{
    [SerializeField] Light _light;

    float _weatherTime;
    float _randomTime; 
    public enum Weather { sun,rain};
    public Weather _currentWeather;
    public ParticleSystem _rain;
    public int _nextWeather;


    // Start is called before the first frame update
    void Start()
    {
       
        _currentWeather = Weather.sun;
        _nextWeather = 1;
        _randomTime = Random.Range(10f, 180f);
        _weatherTime = _randomTime;

    }

    public void ChangeWeather(Weather weatherType)
    {
        if (weatherType != _currentWeather)
        {
            switch (weatherType)
            {
                case Weather.sun:
                    _currentWeather = Weather.sun;
                    _rain.Stop();
                    _light.color = Color.white;
                    break;
                case Weather.rain:
                    _currentWeather = Weather.rain;
                    _rain.Play();
                    _light.color = Color.gray;
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        _weatherTime -= Time.deltaTime; //10초에서 180초 동안 랜덤한 시간에 그 날씨 유지
        if (_nextWeather == 1) //다음 날씨가 '눈'이고
        {
            if (_weatherTime <= 0) //현재 날씨의 제한시간이 끝나면
            {
                _nextWeather = Random.Range(0, 2); //다음 날씨 계산(0 - 맑음, 1 - 비)
                ChangeWeather(Weather.rain); //눈으로 바꿔줌
                _weatherTime = _randomTime;
            }
        }
        if (_nextWeather == 0) //다음 날씨가 '맑음'이고
        {
            if (_weatherTime <= 0) //현재 날씨의 제한시간이 끝나면
            {
                _nextWeather = Random.Range(0, 2); //다음 날씨 계산(0 - 맑음, 1 -비)
                ChangeWeather(Weather.sun); //맑음으로 바꿔줌
                _weatherTime = _randomTime;
            }
        }



    }
    
}
