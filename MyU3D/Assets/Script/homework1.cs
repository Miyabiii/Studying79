using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class homework1 : MonoBehaviour
{
    public GameObject quad;
    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    //数组
    public GameObject[] quads;
    public GameObject[] cubes;
    public GameObject[] spheres;
    public GameObject[] cylinders;

    public int num = 5;  //复制数量
    public Vector3 startPos;  //开始位置
    //public float offset;  //偏移量
    float[] offset1;
    float[] offset2;
    float[] offset3;

    public float speed;  //移动速度
    public float time = 0;
    public float destroyDis = 100f;  //销毁单位

    void Start()
    {
        quads = new GameObject[num];
        cubes = new GameObject[num];
        spheres = new GameObject[num];
        cylinders = new GameObject[num];

        offset1 = new float[num];
        offset2 = new float[num];
        offset3 = new float[num];

        quad = GameObject.Find("MyQuad");
        cube = GameObject.Find("MyCube");
        sphere = GameObject.Find("MySphere");
        cylinder = GameObject.Find("MyCylinder");

        startPos = quad.transform.position;

        for (int i = 0; i < num; i++)
        {
            quads[i] = Instantiate(quad, new Vector3(0, 0, 0), Quaternion.identity);
            quads[i].name = quad.name + (i + 1);
            quads[i].transform.parent = quad.transform.parent;

            cubes[i] = Instantiate(cube, new Vector3(0, 0, 0), Quaternion.identity);
            cubes[i].name = cube.name + (i + 1);
            cubes[i].transform.parent = cube.transform.parent;

            cylinders[i] = Instantiate(cylinder, new Vector3(0, 0, 0), Quaternion.identity);
            cylinders[i].name = cylinder.name + (i + 1);
            cylinders[i].transform.parent = cylinder.transform.parent;

            spheres[i] = Instantiate(sphere, new Vector3(0, 0, 0), Quaternion.identity);
            spheres[i].name = sphere.name + (i + 1);
            spheres[i].transform.parent = sphere.transform.parent;

            offset1[i] = Random.Range(0f, 1f);  //随机偏移量
            offset2[i] = Random.Range(0f, 1f);  //随机偏移量
            offset3[i] = Random.Range(0f, 1f);  //随机偏移量
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        for (int i = 0; i < num; i++)
        {
            if (cubes[i] != null)
            {
                //Debug.Log("offset" + offset);
                speed = 2 + offset1[i] * 1;
                //每帧朝x方向移动
                cubes[i].transform.Translate(Vector3.right * speed * Time.deltaTime);
                //超过销毁距离
                if (Vector3.Distance(startPos, cubes[i].transform.position) >= destroyDis)
                {
                    Destroy(cubes[i]);
                }
            }
        }

        for (int i = 0; i < num; i++)
        {
            if (spheres[i] != null)
            {
                speed = 3 + offset2[i] * 1;
                //每帧朝y方向移动
                spheres[i].transform.Translate(Vector3.up * speed * Time.deltaTime);
                // 超过销毁距离
                if (Vector3.Distance(startPos, spheres[i].transform.position) >= destroyDis)
                {
                    Destroy(spheres[i]);
                }
            }
        }

        for (int i = 0; i < num; i++)
        {
            if (cylinders[i] != null)
            {
                speed = 3 + offset3[i] * 1;
                //每帧朝z方向移动
                cylinders[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if (time > 5f)   //大于5秒时
        {
            for (int i = 0; i < num; i++)
            {
                Destroy(quads[i]);
            }
        }
    }
}
