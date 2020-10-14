using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSphere : MonoBehaviour
{
    public float friction;
    public float mass;
    public float radius;

    public GameObject other;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject upWall;
    public GameObject downWall;

    float x_left;
    float x_right;
    float z_up;
    float z_down;

    [NonSerialized]
    public Vector3 currentV;

    // Start is called before the first frame update
    void Start()
    {
        currentV = Vector3.zero;
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");
        upWall = GameObject.Find("UpWall");
        downWall = GameObject.Find("DownWall");

        x_left = leftWall.transform.position.x + leftWall.transform.localScale.x / 2;
        x_right = rightWall.transform.position.x - rightWall.transform.localScale.x / 2;
        z_up = upWall.transform.position.z - upWall.transform.localScale.z / 2;
        z_down = downWall.transform.position.z + downWall.transform.localScale.z / 2;
    }

    // Update is called once per frame
    void Update()
    {

        //摩擦力
        Vector3 frictionDeltaV = -Time.deltaTime * friction * currentV.normalized;
        //防止摩擦力反向运动
        Vector3 finalV = currentV + frictionDeltaV;
        if (finalV.x * currentV.x <= 0)
            frictionDeltaV.x = -currentV.x;
        if (finalV.y * currentV.y <= 0)
            frictionDeltaV.y = -currentV.y;
        if (finalV.z * currentV.z <= 0)
            frictionDeltaV.z = -currentV.z;

        //应用加速度
        Vector3 curV = currentV + frictionDeltaV;
        transform.Translate((curV + currentV) * Time.deltaTime / 2);
        currentV = curV;

        // 检测与墙体的碰撞
        Vector3 pos = transform.position;
        if (leftWall != null && rightWall != null && upWall != null && downWall != null)
        {
            if (pos.x < x_left + radius)
            {
                Debug.Log("大球撞左墙了");
                currentV.x = -currentV.x;
            }
            if (pos.x > x_right - radius)
            {
                Debug.Log("大球撞右墙了");
                currentV.x = -currentV.x;
            }
            if (pos.z < z_down + radius)
            {
                Debug.Log("大球撞下墙了");
                currentV.z = -currentV.z;
            }
            if (pos.z > z_up - radius)
            {
                Debug.Log("大球撞上墙了");
                currentV.z = -currentV.z;
            }
        }

    }
}
