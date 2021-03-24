using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    var singletonObject = new GameObject();
                    singletonObject.name = typeof(T).ToString();
                    _instance = singletonObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }
}
