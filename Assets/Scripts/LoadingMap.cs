using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;




public class LoadingMap : MonoBehaviour
{

    [SerializeField] GameObject[] mapPrefabs;
    [SerializeField] int _duration = 1;
    NavMeshSurface _surface;

    

    private void Awake()
    {
        _surface = GetComponent<NavMeshSurface>();
    }
    
    void Start()
    {
        
        Terrain();
        Ocean();
        Road();
        HumanRoad();
        Building();
        Environment();
        car();
        //Task.Run(() => Terrain());
        //Task.Run(() => Ocean());
        //Task.Run(() => Road());
        //Task.Run(() => Building());
        //Task.Run(() => car());
        //Task.Run(() => HumanRoad());
        //Task.Run(() => Environment());
    }



    void Terrain()
    {
            GameObject terrain = Instantiate(mapPrefabs[0]);
            terrain.GetComponent<NavMeshSurface>().BuildNavMesh();
            
        
       
    }
     void Ocean()
    {

       
            Instantiate(mapPrefabs[1]);
         
    }

   void Road()
    {


        GameObject Road = Instantiate(mapPrefabs[2]);
        //Road.GetComponent<NavMeshSurface>().BuildNavMesh();    

            
        
    }

    void HumanRoad()
    {


        GameObject HumanRoad =   Instantiate(mapPrefabs[3]);
        //HumanRoad.GetComponent<NavMeshSurface>().BuildNavMesh();    

        
    }

    

    void Building()
    {

            Instantiate(mapPrefabs[4]);

    }

    void Environment()
    {

        GameObject Environment =   Instantiate(mapPrefabs[5]);
        //Environment.GetComponent<NavMeshSurface>().BuildNavMesh();    

        
    }

    void car()
    {

            Instantiate(mapPrefabs[6]);  
       
    }



}










