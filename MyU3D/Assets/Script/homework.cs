using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class homework : MonoBehaviour
{
    GameObject root;
    GameObject quad;
    GameObject cube;
    GameObject sphere;
    GameObject cylinder;

    int num;  //复制数量
    void Start()
    {
        num = 5;

        quad = GameObject.Find("MyQuad");
        cube = GameObject.Find("MyCube");
        sphere = GameObject.Find("MySphere");
        cylinder = GameObject.Find("MyCylinder");

        root = GameObject.Find("Root");

        for (int i = 0; i < num; i++)  //生成num个
        {
            CreateGameObject(quad, i);
            CreateGameObject(cube, i);
            CreateGameObject(sphere, i);
            CreateGameObject(cylinder, i);
        }

        PrintChildren(root.transform, 0);
    }

    void CreateGameObject(GameObject t, int i)
    {
        GameObject obj = Instantiate(t, new Vector3(0, 0, 0), Quaternion.identity);
        obj.name = t.name + (i + 1);
        obj.transform.parent = t.transform.parent;
    }

    void PrintChildren(Transform parent, int level)
    {
        string prefix;//前缀

        if (level == 0)  //第一层没有前缀
        {
            prefix = new string("");
            Debug.Log(prefix + parent.name);
        }
        else
        {
            prefix = new string('#', (level * 2) - level); //表示层级的前缀

            Debug.Log(prefix + parent.name);
        }

        foreach (Transform child in parent)
        {
            PrintChildren(child, level + 1);
        }
    }
}
