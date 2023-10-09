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
       
        _weatherTime -= Time.deltaTime; //10�ʿ��� 180�� ���� ������ �ð��� �� ���� ����
        if (_nextWeather == 1) //���� ������ '��'�̰�
        {
            if (_weatherTime <= 0) //���� ������ ���ѽð��� ������
            {
                _nextWeather = Random.Range(0, 2); //���� ���� ���(0 - ����, 1 - ��)
                ChangeWeather(Weather.rain); //������ �ٲ���
                _weatherTime = _randomTime;
            }
        }
        if (_nextWeather == 0) //���� ������ '����'�̰�
        {
            if (_weatherTime <= 0) //���� ������ ���ѽð��� ������
            {
                _nextWeather = Random.Range(0, 2); //���� ���� ���(0 - ����, 1 -��)
                ChangeWeather(Weather.sun); //�������� �ٲ���
                _weatherTime = _randomTime;
            }
        }



    }
    
}
