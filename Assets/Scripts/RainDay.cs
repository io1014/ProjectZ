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
        _rain = GetComponent<ParticleSystem>();
        _currentWeather = Weather.sun;
        _nextWeather = 1;
        _randomTime = Random.Range(10f, 180f);
        _weatherTime = _randomTime;

    }

    // Update is called once per frame
    void Update()
    {
        this._weatherTime -= Time.deltaTime; //10�ʿ��� 180�� ���� ������ �ð��� �� ���� ����
        if (_nextWeather == 1) //���� ������ '��'�̰�
        {
            if (this._weatherTime<= 0) //���� ������ ���ѽð��� ������
            {
                _nextWeather = Random.Range(0, 2); //���� ���� ���(0 - ����, 1 - ��)
                ChangeWeather(Weather.rain); //������ �ٲ���
                _weatherTime = Random.Range(0,180);
            }
        }
        if (_nextWeather == 0) //���� ������ '����'�̰�
        {
            if (this._weatherTime <= 0) //���� ������ ���ѽð��� ������
            {
                _nextWeather = Random.Range(0, 2); //���� ���� ���(0 - ����, 1 -��)
                ChangeWeather(Weather.sun); //�������� �ٲ���
                _weatherTime = Random.Range(0,180);
            }
        }



    }
    public void ChangeWeather(Weather weatherType)
    {
        if (weatherType != this._currentWeather)
        {
            switch (weatherType)
            {
                case Weather.sun:
                    _currentWeather = Weather.sun;
                    this._rain.Stop();
                    _light.color = Color.clear;
                    break;
                case Weather.rain:
                    _currentWeather = Weather.rain;
                    this._rain.Play();
                    _light.color = Color.black;
                    break;
            }
        }

    }
}
