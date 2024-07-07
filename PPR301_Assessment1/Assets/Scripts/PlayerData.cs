using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Door_Open_Conditional doc1;
    public Door_Open_Conditional doc2;
    public Door_Open_Conditional doc3;

    public float[] position;

    public bool col1;
    public bool col2;
    public bool col3;
    public bool col4;
    public bool col5;
    public bool col6;
    public bool col7;
    public bool col8;
    public bool col9;
    public bool col10;

    public int collectables;

    public PlayerData (EquipScript equipScript)
    {
        position = new float[3];
        position[0] = equipScript.Player.transform.position.x;
        position[1] = equipScript.Player.transform.position.y;
        position[2] = equipScript.Player.transform.position.z;

        collectables = equipScript.collectableNum;

    }
}
