using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class homework : MonoBehaviour
{
    public GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("Root");

        // foreach (Transform child in root.transform)
        // {
        //     GameObject childObj = child.gameObject;
        //     Debug.Log(childObj.name);
        // }
        foreach (Transform child in root.GetComponentsInChildren<Transform>())
        {
            GameObject childObj = child.gameObject;
            Debug.Log(childObj.name);
        }
        // for (int i = 0; i < 100; i++)
        // {
        //     Transform[] MyChild;
        //     MyChild = root.GetComponentsInChildren<Transform>();
        //     for (int j = 0; j < 100; j++)
        //     {
        //         Debug.Log(MyChild[j].name);
        //     }

        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
