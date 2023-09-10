using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoBehaviour
{
public static T Instance {get; private set;} 

protected virtual void Awake()
{
    if (Instance != null)
        {
            Debug.LogError("singleton error!!  " + transform + " " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this as T;
}

}
