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
    public GameObject monstre;
    public GameObject hero;
    public GameObject PrefabProjectille;
    public GameObject PrefabPiege;


    void Start()
    {
        equipeMonstre = new List<GameObject>();
        equipeNpc = new List<GameObject>();
        equipeJoueur = new List<GameObject>();
        //equipeJoueur.Add(FindObjectOfType<ScriptHealer>().gameObject);
        //equipeMonstre.Add(FindObjectOfType<ScriptMonstre>().gameObject);
        //equipeNpc.Add(FindObjectOfType<ScriptMouvementNPC>().gameObject);
        //mainCamera = FindObjectOfType<ScriptCamera>().gameObject;
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
        //Debug.Log("DA : TrouverElementPlusProche ->"+ cible);
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

    public void CreateMonstre()
    {
        int nbMonstre=5;
        
        for (int i = 0; i < nbMonstre; i++)
        {
            GameObject m = Instantiate(monstre);
            equipeMonstre.Add(m);
            m.transform.position = m.transform.position + new Vector3(0+i*3, 0, 0+i*3);
        }
    }

    public void MonstreMeure(int levelMonstre)
    {
        foreach (GameObject elem in equipeJoueur)
        {
            if (elem.GetComponent<ScriptHealer>())
            {
                elem.GetComponent<ScriptHealer>().GainExperience(15*levelMonstre);
            }
            else if (elem.GetComponent<ScriptTank>())
            {
                elem.GetComponent<ScriptTank>().GainExperience(15 * levelMonstre);
            }
            else if (elem.GetComponent<ScriptDps>())
            {
                elem.GetComponent<ScriptDps>().GainExperience(15 * levelMonstre);
            }
        }
    }

    public void InitSceneDps()
    {
        Vector3 heroPos = new Vector3(0, 0, 0);
        GameObject h = Instantiate(hero);
        h.transform.position = heroPos;
        h.AddComponent<ScriptDps>();
        h.GetComponent<ScriptDps>().projectile = PrefabProjectille;
        equipeJoueur.Add(h);
        CreateMonstre();
    }

    public void InitSceneTank()
    {
        InitSceneDps();
    }

    public void InitSceneHealer()
    {
        Vector3 heroPos = new Vector3(0, 0, 0);
        GameObject h = Instantiate(hero);
        h.transform.position = heroPos;
        h.AddComponent<ScriptHealer>();
        h.GetComponent<ScriptHealer>().piege = PrefabPiege;
        equipeJoueur.Add(h);
        CreateMonstre();
    }
}

