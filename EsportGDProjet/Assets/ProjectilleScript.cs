using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int attaque;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetAttaque()
    {
        return attaque;
    }
    public void SetAttaque(int atk)
    {
        attaque = atk;
    }
}
