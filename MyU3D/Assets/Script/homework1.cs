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

    public List<GameObject> quads = new List<GameObject>();
    public List<GameObject> cubes = new List<GameObject>();
    public List<GameObject> spheres = new List<GameObject>();
    public List<GameObject> cylinders = new List<GameObject>();

    public int num = 5;  //复制数量
    public Vector3 startPos;  //开始位置
    //public float offset;  //偏移量
    float[] offset1 = new float[10];
    float[] offset2 = new float[10];
    float[] offset3 = new float[10];

    public float speed;  //移动速度
    public float time = 0;
    public float destroyDis = 100f;  //销毁单位

    void Start()
    {

        quad = GameObject.Find("MyQuad");
        cube = GameObject.Find("MyCube");
        sphere = GameObject.Find("MySphere");
        cylinder = GameObject.Find("MyCylinder");

        startPos = quad.transform.position;

        for (int i = 0; i < num; i++)
        {
            //Vector3 position = startPosition + i * offset;
            GameObject newObj1 = Instantiate(quad, quad.transform.parent);
            newObj1.name = quad.name + (i + 1);
            quads.Add(newObj1);

            GameObject newObj2 = Instantiate(cube, cube.transform.parent);
            newObj2.name = cube.name + (i + 1);
            cubes.Add(newObj2);

            GameObject newObj3 = Instantiate(sphere, sphere.transform.parent);
            newObj3.name = sphere.name + (i + 1);
            spheres.Add(newObj3);

            GameObject newObj4 = Instantiate(cylinder, cylinder.transform.parent);
            newObj4.name = cylinder.name + (i + 1);
            cylinders.Add(newObj4);

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
            //offset = Random.Range(0f, 1f);  //随机偏移量
            //Debug.Log("offset" + offset);
            speed = 2 + offset1[i] * 1;
            // Debug.Log("speed" + speed);
            //每帧朝x方向移动
            cubes[i].transform.Translate(Vector3.right * speed * Time.deltaTime);
            //超过销毁距离
            if (Vector3.Distance(startPos, cubes[i].transform.position) >= destroyDis)
            {
                Destroy(cubes[i]);
            }
        }

        for (int i = 0; i < num; i++)
        {
            //offset = Random.Range(0f, 1f);  //随机偏移量
            speed = 3 + offset2[i] * 1;
            //每帧朝y方向移动
            spheres[i].transform.Translate(Vector3.up * speed * Time.deltaTime);
            // 超过销毁距离
            if (Vector3.Distance(startPos, spheres[i].transform.position) >= destroyDis)
            {
                Destroy(spheres[i]);
            }
        }

        for (int i = 0; i < num; i++)
        {
            //offset = Random.Range(0f, 1f);  //随机偏移量
            speed = 3 + offset3[i] * 1;
            //每帧朝z方向移动
            cylinders[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
