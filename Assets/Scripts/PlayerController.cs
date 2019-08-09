using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//边界类
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    //移动速度
    public float speed;
    //偏移角度
    public float tilt;
    public Boundary boundary;

    //下一发子弹的时间
    private float nextFire;
    //子弹发射间隔
    public float fireInterval;
    //子弹
    public GameObject shot;
    //子弹发射点
    public Transform shotSqawn;

    //MouseStatus m_mouse;

    // Start is called before the first frame update
    void Start()
    {
        //m_mouse = new MouseStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) //PC: Input.GetButton("Fire1") && Time.time > nextFire
        {
            nextFire = Time.time + fireInterval;
            Instantiate(shot, shotSqawn.position, shotSqawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    //private void LateUpdate()
    //{
    //    m_mouse.update();
    //}

    private void FixedUpdate()
    {
        //获得水平方向
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //获得垂直方向
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //获得速度属性
        //GetComponent<Rigidbody>().velocity = movement * speed;

        //获得旋转属性
        //GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

        int touchNum = Input.touchCount;

        if (touchNum > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 dir = new Vector3(touch.deltaPosition.x, 0.0f, touch.deltaPosition.y) * speed;
                transform.Translate(dir);
            }
        }

        //限制在一个范围内移动
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

    }
}
