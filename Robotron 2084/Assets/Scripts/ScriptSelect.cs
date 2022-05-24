using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSelect : MonoBehaviour
{
    float changeTimer;//设定一个计时器，每过一段时间，机器人换一个方向运动
    public float changeTime = 10f;//计时器长度
    private bool status = true;
    // Start is called before the first frame update
    void Start()
    {
        change();
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;//计时器每一帧都减小
        if (changeTimer < 0)
        {
            change();
            changeTimer = changeTime;//改变方向后计时器重新初始化
        }
    }

    public void change()
    {
        if (status == true)
        {
            GameObject.Find("Robot/Robot").GetComponent<AIPath>().enabled = true;
            GameObject.Find("Robot/Robot").GetComponent<RobotControl>().enabled = false;
            status = false;
            return;
        }
        if (status == false)
        {
            GameObject.Find("Robot/Robot").GetComponent<AIPath>().enabled = false;
            GameObject.Find("Robot/Robot").GetComponent<RobotControl>().enabled = true;
            status = true;
            return;
        }
    }
}
