using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class LoadingMap : MonoBehaviour
{

    [SerializeField] GameObject[] mapPrefabs;


    

    // Start is called before the first frame update
    void Start()
    {

        Terrain();
        Ocean();
        Road();
        HumanRoad();
        Building();
        Environment();
        car();

    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void Terrain()
    {
        Instantiate(mapPrefabs[0]);
    }
     void Ocean()
    {
       
        
            Instantiate(mapPrefabs[1]);
         
    }

    void Road()
    {
        
            Instantiate(mapPrefabs[2]);
            
        
    }

    void HumanRoad()
    {
            Instantiate(mapPrefabs[3]);  
        
    }

    

    void Building()
    {

            Instantiate(mapPrefabs[4]);
            
        
    }

    void Environment()
    {
        
            Instantiate(mapPrefabs[5]);  
        
    }

    void car()
    {
      
            Instantiate(mapPrefabs[6]);  
       
    }



}










public delegate void LoadDelegate();
