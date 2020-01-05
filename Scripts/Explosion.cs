using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Explosion : MonoBehaviour
{
    public float ExplosionTime = 1f;
    private void Start()
    {
        Destroy(this.gameObject, ExplosionTime);
    }
}
