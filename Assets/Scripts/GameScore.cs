using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    void Start()
    {
        GameSetting.instance.ShowScore();
    }
}
