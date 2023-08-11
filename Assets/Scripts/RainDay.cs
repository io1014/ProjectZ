using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDay : MonoBehaviour
{
    [SerializeField] float _realTime;
    [SerializeField] Light _light;
    float _dayFog;
    float _currentFogDensity;

    bool _isRainDay = false;

    // Start is called before the first frame update
    void Start()
    {
        _dayFog = RenderSettings.fogDensity;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int randomTime = Random.Range(1, 7200);
       
        Invoke("Rainy", _realTime * Time.deltaTime );
        
       
        
    }


    void Rainy()
    {
        gameObject.SetActive(true);
        _isRainDay = true;
        RainyGloomy();
    }

    

    void RainyGloomy()
    {
        if(_isRainDay == true)
        {
            _light.color = Color.black;
        }
    }

}
