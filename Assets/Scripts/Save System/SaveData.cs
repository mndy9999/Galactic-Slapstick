using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public int[] topSeconds;

    public SaveData(int seconds1, int seconds2, int seconds3)
    {
        topSeconds = new int[3];
        topSeconds[0] = seconds1;
        topSeconds[1] = seconds2;
        topSeconds[2] = seconds3;
    }

}

