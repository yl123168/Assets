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
    /// <summary>
    /// 坦克运动速度
    /// </summary>
    public float moveSpeed = 5;
    private SpriteRenderer sr;
    /// <summary>
    /// 玩家坦克四个方向图片
    /// </summary>
    public Sprite[] tankAnim;//up right down left
    /// <summary>
    /// 子弹预制件
    /// </summary>
    public GameObject bulletPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        TankMovement();
    }

    /// <summary>
    /// 玩家发射子弹攻击
    /// </summary>
    private void Attack() {
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }


    /// <summary>
    /// 坦克运动
    /// </summary>
    private void TankMovement()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizon != 0 || vertical != 0)
        {
            if (horizon != 0) vertical = 0;
            if (horizon < 0)
            {
                sr.sprite = tankAnim[3];
            }
            else if (horizon > 0)
            {
                sr.sprite = tankAnim[1];
            }
            if (vertical < 0)
            {
                sr.sprite = tankAnim[2];
            }
            else if (vertical > 0)
            {
                sr.sprite = tankAnim[0];
            }
            this.transform.Translate(horizon * moveSpeed * Time.fixedDeltaTime, vertical * moveSpeed * Time.fixedDeltaTime, 0, Space.World);
        }
    }
}
