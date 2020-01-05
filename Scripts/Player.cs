using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Player : MonoBehaviour
{
    private float horizon;
    private float vertical;
    public float moveSpeed=5;
    private SpriteRenderer sr;
    public Sprite[] tankAnim;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        horizon = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizon != 0 || vertical != 0)
        {
            this.transform.Translate(horizon*moveSpeed*Time.deltaTime, vertical*moveSpeed*Time.deltaTime, 0,Space.World);
        }
    }
}
