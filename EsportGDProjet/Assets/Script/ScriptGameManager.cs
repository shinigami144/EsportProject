using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Temporaire au test
    private int idGm;
    private static int numberGm = 1;
    private List<GameObject> equipeMonstre;
    private List<GameObject> equipeNpc;
    private List<GameObject> equipeJoueur;
    private AsyncOperation sceneToWait;

    // Global au jeu
    public List<GameObject> equipeMonstreGloabl;
    public List<GameObject> equipeNpcGlobal;
    public List<GameObject> equipeJoueurGlobal;
    // test:






    // test
    public GameObject PrefabMonstre;
    public GameObject PrefabHero;
    public GameObject PrefabNpc;
    public GameObject PrefabProjectille;
    public GameObject PrefabPiege;

    private void Awake()
    {
        idGm = numberGm;
        numberGm++;
        if (numberGm > 1)
        {
            if (idGm != 1)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        equipeMonstre = new List<GameObject>();
        equipeNpc = new List<GameObject>();
        equipeJoueur = new List<GameObject>();
        equipeMonstreGloabl = new List<GameObject>();
        equipeNpcGlobal = new List<GameObject>();
        equipeJoueurGlobal = new List<GameObject>();
        InitData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void InitData()
    {
        // Hero + position
        GameObject tem = Instantiate(PrefabHero);
        tem.transform.position = new Vector3(-0.4f, 0.5f, -6f);
        equipeJoueurGlobal.Add(tem);
        // Npc Dps + position
        equipeNpcGlobal.Add(CreeNpcDps(new Vector3(-6f,0.5f,3f)));
        // Npc Tank + position
        equipeNpcGlobal.Add(CreeNpcTank(new Vector3(0f, 0.5f, 3f)));
        // Npc Healer +  position
        equipeNpcGlobal.Add(CreeNpcHealer(new Vector3(6f, 0.5f, 3f)));
    }


    public GameObject CreeNpcDps(Vector3 position)
    {
        GameObject tempNpc = Instantiate(PrefabNpc);
        tempNpc.transform.position = position;
        tempNpc.AddComponent<ScriptDps>();
        tempNpc.GetComponent<ScriptDps>().projectile = PrefabProjectille;
        return tempNpc;
    }

    public GameObject CreeNpcTank(Vector3 position)
    {
        GameObject tempNpc = Instantiate(PrefabNpc);
        tempNpc.transform.position = position;
        tempNpc.AddComponent<ScriptTank>();
        return tempNpc;
    }

    public GameObject CreeNpcHealer(Vector3 position)
    {
        GameObject tempNpc = Instantiate(PrefabNpc);
        tempNpc.transform.position = position;
        tempNpc.AddComponent<ScriptHealer>();
        tempNpc.GetComponent<ScriptHealer>().piege = PrefabPiege;
        return tempNpc;
    }

    public void InitMainScene()
    {
        // verifier qui il y a dans la liste Global des perso les instantier 
        // 
    }

    public GameObject TrouverHero()
    {
        return equipeJoueur[0];
    }

    public GameObject TrouverMonstrePlusProche(Vector3 vPosition)
    {
        GameObject cible = null;
        float distanceCalculer;
        float distance = 1000000;
        for (int i = 0; i < equipeMonstre.Count; i++)
        {
            distanceCalculer = Vector3.Distance(vPosition, equipeMonstre[i].transform.position);
            if (distance > distanceCalculer)
            {
                cible = equipeMonstre[i];
            }
        }
        return cible;
    }

    public GameObject TrouverElementPlusProche(Vector3 vPosition)
    {
        GameObject cible = null;
        float distanceCalculer;
        float distance = 1000000;
        for(int i = 0;i< equipeJoueur.Count; i++)
        {
            distanceCalculer = Vector3.Distance(vPosition, equipeJoueur[i].transform.position);
            if(distance > distanceCalculer)
            {
                cible = equipeJoueur[i];
                distance = distanceCalculer;
            }
        }
        //Debug.Log("DA : TrouverElementPlusProche ->" + cible);
        return cible;
    }

    public List<GameObject> GetEquipeJoueur()
    {
        return equipeJoueur;
    }

    public List<GameObject> GetEquipeMonstre()
    {
        return equipeMonstre;
    }

    public void CreateMonstre()
    {
        int nbMonstre=5;
        
        for (int i = 0; i < nbMonstre; i++)
        {
            GameObject m = Instantiate(PrefabMonstre);
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

    private IEnumerator RoutineLoadDpsScene()
    {
        while (!sceneToWait.isDone)
        {
            yield return new WaitForSeconds(0.01f);
        }
        InitSceneDps();
        StopCoroutine("RoutineLoadFPSscene");
    }


    public void LoadDpsTraining(int difficultyLevel)
    {
        sceneToWait = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        StartCoroutine("RoutineLoadDpsScene");
    }

    public void InitSceneDps()
    {
        // Hero
        PrefabHero.transform.position = new Vector3(-42, 2.5f, 0);
        GameObject Player = Instantiate(PrefabHero);
        Player.AddComponent<ScriptDps>();
        Player.GetComponent<ScriptDps>().projectile = PrefabProjectille;
        //Player.GetComponent<ClassUnite>().CopyConstructor(equipeJoueurGlobal[0].GetComponent<ClassUnite>());
        equipeJoueur.Add(Player);
        // Monstre


    }

    public void InitSceneTank()
    {
        //InitSceneDps(d);
    }

    public void InitSceneHealer()
    {
        Vector3 heroPos = new Vector3(0, 0, 0);
        GameObject h = Instantiate(PrefabHero);
        h.transform.position = heroPos;
        h.AddComponent<ScriptHealer>();
        h.GetComponent<ScriptHealer>().piege = PrefabPiege;
        equipeJoueur.Add(h);
        CreateMonstre();
        GetComponent<ScriptCiblageAutre>().NPCCiblageDPS();
    }
}

