﻿using System.Collections;
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
    public Vector3 bulletAngel;

    public float attackDelayTime = 1f;
    public float timeCount = 1f;

    public GameObject ExplosionEffectPrefab;
    public  GameObject ShieldEffect;
    private bool IsShield;
    public float shieldTime = 3;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        IsShield = true;
    }

    private void Update()
    {
        CheckShield();
        Attack();
    }

    private void FixedUpdate()
    {
        TankMovement();
    }

    private void CheckShield() {
        //如果没有护盾不要检查了
        if (IsShield == false) return;
        //如果护盾时间为0护盾时效
        if (shieldTime <= 0) {
            IsShield = false;
            ShieldEffect.SetActive(false);
        }
        //护盾时间减少
        shieldTime -= Time.deltaTime;
    }

    /// <summary>
    /// 玩家按空格键发射子弹攻击
    /// </summary>
    private void Attack() {
        timeCount += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeCount>=attackDelayTime)
        {
            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度
            Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(bulletAngel));
            timeCount = 0;
        }
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
                bulletAngel = new Vector3(0, 0, 90);
            }
            else if (horizon > 0)
            {
                sr.sprite = tankAnim[1];
                bulletAngel = new Vector3(0, 0, -90);
            }
            if (vertical < 0)
            {
                sr.sprite = tankAnim[2];
                bulletAngel = new Vector3(0, 0, 180);
            }
            else if (vertical > 0)
            {
                sr.sprite = tankAnim[0];
                bulletAngel = new Vector3(0, 0, 0);
            }
            this.transform.Translate(horizon * moveSpeed * Time.fixedDeltaTime, vertical * moveSpeed * Time.fixedDeltaTime, 0, Space.World);
        }
    }

    public void Death() {
        //无敌不死
        if (IsShield) return;
        //产生爆炸特效
        Instantiate(ExplosionEffectPrefab, this.transform.position, this.transform.rotation);
        //死亡
        Destroy(this.gameObject);
        //重新生成
    }
}
