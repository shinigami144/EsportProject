using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float debutVie;
    private int attaque;
    void Start()
    {
        debutVie = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time -debutVie > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Time.deltaTime > 1)
        {
            Destroy(gameObject);
        }
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
