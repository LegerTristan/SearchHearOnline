using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Start()
    {
        Init();
    }

    void Init()
    {
        PlayerManager.Instance?.Register(this);
    }

}
