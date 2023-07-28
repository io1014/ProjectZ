using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{

    [SerializeField] Maps setmap;
    
 

}



public enum Maps
{
    Building,
    Road,
    HumanRoadAll,
    Car,
    environment,
    Terrain,
    ocean
}
