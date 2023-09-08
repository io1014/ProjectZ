using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static GenericSingleton<T> _instance;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            Debug.Log(gameObject.name);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
