using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> EquipeMonstre;
    List<GameObject> EquipeNpc;
    List<GameObject> EquipeJoueur;
    void Start()
    {
        EquipeMonstre = new List<GameObject>();
        EquipeNpc = new List<GameObject>();
        EquipeJoueur = new List<GameObject>();
        EquipeJoueur.Add(FindObjectOfType<ScriptHealer>().gameObject);
        EquipeMonstre.Add(FindObjectOfType<ScriptMonstre>().gameObject);
        EquipeNpc.Add(FindObjectOfType<ScriptMouvementNPC>().gameObject);
        EquipeJoueur.Add(FindObjectOfType<ScriptTank>().gameObject);
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
        for(int i = 0;i< EquipeJoueur.Count; i++)
        {
            distanceCalculer = (int)CalculerDistanceEntreDeuxPoint(vPosition, EquipeJoueur[i].transform.position);
            if(distance > distanceCalculer)
            {
                cible = EquipeJoueur[i];
            }
        }
        Debug.Log("DA : TrouverElementPlusProche ->"+ cible);
        return cible;
    }
}
