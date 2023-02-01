using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTemplate<TManager> : MonoBehaviour where TManager : MonoBehaviour
{
    public static TManager Instance => instance;

    static TManager instance = null;

    void Awake() => InitManager();

    private void InitManager()
    {
        if(instance)
        {
            Destroy(instance.gameObject);
            return;
        }

        instance = this as TManager;
        name = $"[MANAGER_{instance.GetType().Name}]";
    }
}
