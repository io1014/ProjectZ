using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{  
    
    public GameObject _telehome;
    public GameObject _telefac;
    public GameObject _televillage;
    public GameObject _telev2;
    public GameObject _Player;



    private void Update()
    {
        float distH = Vector3.Distance(_Player.transform.position, _telehome.transform.position);
        float distF = Vector3.Distance(_Player.transform.position, _telefac.transform.position);
        float distV = Vector3.Distance(_Player.transform.position, _televillage.transform.position);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(distH+", "+distF+","+distV);
        }
        if (distH < 1f && Input.GetKeyDown(KeyCode.Space))
        {
            TPHome();
        }
        else if(distF < 1f && Input.GetKeyDown(KeyCode.Space))
        {
            TPFactory();
        }
        else if( distV < 1f && Input.GetKeyDown(KeyCode.Space))
        {
            TPVillage();
        }

    }

  

    void TPHome()
    {
 
            _Player.GetComponent<NavMeshAgent>().enabled = false;
            _Player.transform.position = _telev2.transform.position;
            _Player.GetComponent<NavMeshAgent>().enabled = true;

       
    }

    void TPVillage()
    {
        Debug.Log("input village");
            _Player.GetComponent<NavMeshAgent>().enabled = false;
            _Player.transform.position = _telefac.transform.position;
            _Player.GetComponent<NavMeshAgent>().enabled = true;

    }

    void TPFactory()
    {

            _Player.GetComponent<NavMeshAgent>().enabled = false;
            _Player.transform.position = _televillage.transform.position;
        _Player.GetComponent<NavMeshAgent>().enabled = true;

    }

    public enum Locate
    {
        home,
        village,
        factory,
        tele2,
    }

}



