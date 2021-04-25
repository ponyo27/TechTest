using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Ships")]
public class PlayerData : ScriptableObject
{
    public string ShipName;
    public string Description;
    public GameObject ShipModel;
    public GameObject ExplosionEffect;
    public int Acceleration;
    public float MaxVelocity;
}
