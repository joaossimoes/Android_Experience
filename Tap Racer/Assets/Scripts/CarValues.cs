using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car")]
public class CarValues : ScriptableObject
{
    public float traction;
    public float BrakePower;
    public float Acceleration;
    public float maxSpeed;
}
