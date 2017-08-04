using UnityEngine;
using System.Collections;
using System;

public class SingletonMonoBehaviour<T> : BaseMonoBehaviour where T : Component
{
    protected static T instance;

    public static void Instantiate()
    {
        instance = GameObject.FindObjectOfType<T>();
        if (instance != null) return;
        instance = new GameObject(typeof(T).FullName).AddComponent<T>();
        GameObject.DontDestroyOnLoad(instance.gameObject);
    }


    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Debug.LogError("There are two instances of " + typeof(T).FullName + "!");
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (instance == this) instance = null;
    }

    public static T Instance
    {
        get
        {
            return GetInstance();
        }
    }

    public static T GetInstance()
    {
        if (instance != null) return instance;
        instance = (T)FindObjectOfType(typeof(T));
        if (instance == null)
        {
            throw new InvalidOperationException("There is no " + typeof(T).FullName + "!");
        }
        return instance;
    }

    public static bool HasInstance()
    {
        if (instance != null) return true;
        instance =


        FindObjectOfType<T>();
        return instance != null;
    }
}

