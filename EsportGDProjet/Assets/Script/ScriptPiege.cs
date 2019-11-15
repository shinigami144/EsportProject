using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPiege : MonoBehaviour
{
    private int atq;

    public int GetAtq()
    {
        return atq;
    }
    
    public void SetAtq(int _atq)
    {
        atq= _atq;
    }
}
