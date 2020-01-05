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
    public float moveSpeed = 5;
    private SpriteRenderer sr;
    public Sprite[] tankAnim;//up right down left

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizon != 0 || vertical != 0)
        {
            TankMovement();
            TankAnim();
        }
    }

    /// <summary>
    /// 坦克根据移动方向变换sprite
    /// </summary>
    private void TankAnim()
    {
        if (horizon < 0) sr.sprite = tankAnim[3];
            else if(horizon>0) sr.sprite = tankAnim[1];
        if (vertical < 0) sr.sprite = tankAnim[2];
            else if(vertical >0 ) sr.sprite = tankAnim[0];
    }

    /// <summary>
    /// 坦克运动
    /// </summary>
    private void TankMovement()
    {
        this.transform.Translate(horizon * moveSpeed * Time.fixedDeltaTime, vertical * moveSpeed * Time.fixedDeltaTime, 0, Space.World);
    }
}
