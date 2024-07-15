using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class homework : MonoBehaviour
{
    public GameObject root;
    void Start()
    {
        root = GameObject.Find("Root");
        PrintChildren(root.transform, 0);
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
