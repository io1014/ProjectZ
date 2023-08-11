using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDay : MonoBehaviour
{
    [SerializeField] float _realTime;
    [SerializeField] float _rainFog;
    [SerializeField] float _rainFogCalc;
    float _dayFog;
    float _currentFogDensity;

    bool _isRainDay = false;

    // Start is called before the first frame update
    void Start()
    {
        _dayFog = RenderSettings.fogDensity;
    }

    // Update is called once per frame
    void Update()
    {
        int randomTime = Random.Range(1, 7200);
       
        Invoke("Rainy", _realTime * Time.deltaTime * randomTime);
        Invoke("RainyStop", _realTime*Time.deltaTime * randomTime);
        
       
        
    }


    void Rainy()
    {
        gameObject.SetActive(true);
        _isRainDay = true;
    }

    void RainyStop()
    {
        gameObject.SetActive(false);
        _isRainDay = false;
    }

}
