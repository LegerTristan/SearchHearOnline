using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float lookSpeed = 20;


    void Start()
    {
        Init();
    }

    private void Update()
    {
        MoveForward();
        Look();
    }

    void Init()
    {
        PlayerManager.Instance?.Register(this);
    }

    void MoveForward()
    {
         transform.position += transform.forward * Input.GetAxis("vertical") * Time.deltaTime * speed ;
    }

    void Look()
    {
        transform.eulerAngles += new Vector3(0, Input.GetAxis("horizontal") * Time.deltaTime * lookSpeed, 0); 
    }

}
