using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        #region Singleton Instance Getter
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();
                if (_instance == null)
                {
                    GameObject singletonGO = new GameObject(typeof(T).Name);
                    _instance = singletonGO.AddComponent<T>();

                }
            }
            return _instance;
        }
        #endregion
    }
    public virtual void Awake()
    {
        #region Singleton Pattern
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this as T;
        DontDestroyOnLoad(gameObject);
        #endregion
    }
}