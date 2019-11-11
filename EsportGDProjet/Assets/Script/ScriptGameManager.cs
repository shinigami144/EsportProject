using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> equipeMonstre;
    private List<GameObject> equipeNpc;
    private List<GameObject> equipeJoueur;
    private GameObject mainCamera;
    void Start()
    {
        equipeMonstre = new List<GameObject>();
        equipeNpc = new List<GameObject>();
        equipeJoueur = new List<GameObject>();
        equipeJoueur.Add(FindObjectOfType<ScriptHealer>().gameObject);
        equipeMonstre.Add(FindObjectOfType<ScriptMonstre>().gameObject);
        equipeNpc.Add(FindObjectOfType<ScriptMouvementNPC>().gameObject);
        mainCamera = FindObjectOfType<ScriptCamera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float CalculerDistanceEntreDeuxPoint(Vector3 pointA,Vector3 pointB)
    {
        float cal = (pointB.x - pointA.x) * (pointB.x - pointA.x) + (pointB.y - pointA.y) * (pointB.y - pointA.y) + (pointB.y - pointA.y) * (pointB.y - pointA.y);
        float value = Mathf.Sqrt(cal);
        return value;
    }

    public GameObject TrouverElementPlusProche(Vector3 vPosition)
    {
        GameObject cible = null;
        int distanceCalculer;
        int distance = 1000000;
        for(int i = 0;i< equipeJoueur.Count; i++)
        {
            distanceCalculer = (int)CalculerDistanceEntreDeuxPoint(vPosition, equipeJoueur[i].transform.position);
            if(distance > distanceCalculer)
            {
                cible = equipeJoueur[i];
            }
        }
        Debug.Log("DA : TrouverElementPlusProche ->"+ cible);
        return cible;
    }

    public GameObject GetCamera()
    {
        return mainCamera;
    } 

    public GameObject GetJoueur()
    {
        return equipeJoueur[0];
    }
}

