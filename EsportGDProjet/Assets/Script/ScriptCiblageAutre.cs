using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCiblageAutre : MonoBehaviour
{
    // Start is called before the first frame update
    // Composant pour les NPC et Monstre
    bool estMonstre;
    ScriptGameManager gm;
    int distanceDeTir = 50;

    void Start()
    {
        gm = FindObjectOfType<ScriptGameManager>();
        if (GetComponent<ScriptMonstre>())
        {
            estMonstre = true;
        }
        else
        {
            estMonstre = false;
        }
    }
    public void NPCCiblageHeal()
    {
        List<GameObject> equipeJoueur;
        equipeJoueur = gm.GetEquipeJoueur();
        GameObject temp;
        temp = equipeJoueur[0];
        for (int i = 1; i < equipeJoueur.Count; i++)
        {
            if (temp.GetComponent<ClassUnite>().GetPointDeVie()>equipeJoueur[i].GetComponent<ClassUnite>().GetPointDeVie())
            {
                temp = equipeJoueur[i];
            }
        }
        GetComponent<ScriptHealer>().Heal(temp);
    }

    public void NPCCiblageDPS()
    {
        List<GameObject> equipeMonstre;
        equipeMonstre = gm.GetEquipeMonstre();
        GameObject temp;
        temp = GetComponent<ScriptGameManager>().TrouverMonstrePlusProche(transform.position);
        Debug.Log("Moi NPC J'attaque : "+temp);
        GetComponent<ScriptDps>().Tirer(temp.transform.position);
    }

    private void Update()
    {
        if (GetComponent<ScriptHealer>() && GetComponent<ScriptMouvementNPC>().InHeroTeam() == true)
        {
            //Debug.Log(gameObject.name);
            NPCCiblageHeal();
        }
        if (GetComponent<ScriptDps>() && GetComponent<ScriptMouvementNPC>().InHeroTeam() == true)
        {
            NPCCiblageDPS();
        }
    }

    public GameObject TrouverCible()
    {
        if (estMonstre)
        {
            return gm.TrouverElementPlusProche(transform.position);
        }
        else
        {
            return gm.TrouverHero();
        }
    }

    public Vector3 TrouvePositonCible()
    {
        return TrouverCible().transform.position;
    }
}