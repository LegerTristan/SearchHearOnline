using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Phase", menuName ="Phase")]
public class Phase : ScriptableObject
{
    [SerializeField] int speed = 2;
    [SerializeField] float radius = 10;

    public int Speed => speed;
    public float Radius => radius;

}
