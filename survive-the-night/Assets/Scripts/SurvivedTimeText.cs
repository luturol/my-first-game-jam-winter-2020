using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivedTimeText : MonoBehaviour
{
    public Text timeCount;

    // Update is called once per frame
    void Update()
    {
        timeCount.text = Portal.formatedTime;
    }
}
