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
    public static LoadingMap instance;

    

    private void Awake()
    {
        instance = this;
        _surface = GetComponent<NavMeshSurface>();
    }
    
   

    public void MapLoad()
    {
        Terrain();
        Ocean();
        Road();
        HumanRoad();
        Building();
        Environment();
        car();

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

           GameObject Building = Instantiate(mapPrefabs[4]);
        //Building.GetComponent<NavMeshSurface>().BuildNavMesh();


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










