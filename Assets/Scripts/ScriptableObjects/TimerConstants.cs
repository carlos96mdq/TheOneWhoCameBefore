using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TimerConstants", order = 2)]
public class TimerConstants : ScriptableObject
{
    public float initialTime;   // Tiempo inicialdel Timer
    public float finishTime;    // Tiempo final del Timer
}
