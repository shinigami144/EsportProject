using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMonstre : MonoBehaviour
{
    // Start is called before the first frame update
    ClassUnite unite;
    int timeur;
    private static int NUMBER_MONSTER;
    ScriptGameManager GameManager;
    bool taunted;
    void Start()
    {
        List<int> lstat = new List<int>();
        timeur = 0;
        unite = gameObject.AddComponent<ClassUnite>();
        unite.SetNom("Monstre" + NUMBER_MONSTER.ToString());
        unite.SetMaxPointDeVie(75);
        unite.SetAttaque(25);
        unite.SetDefence(5);
        unite.SetMouvementVitesse(5);
        unite.SetVitesseAttaque(3);
        NUMBER_MONSTER++;
        GameManager = FindObjectOfType<ScriptGameManager>();
        taunted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (taunted == false)
        {
            Debug.Log("Taunt");
            unite.SetCibleObjet(GetComponent<ScriptCiblageAutre>().TrouverCible());
            
        }
        unite.SetCible(unite.GetCibleObjet().transform.position);
        Debug.Log("Cible " + unite.GetCibleObjet().name);

    }

    public void Attaquer(GameObject cible)
    {
        ClassUnite n = unite.GetComponent<ClassUnite>();
        int degat =unite.GetAttaque() -  unite.GetComponent<ClassUnite>().GetDefence();
        cible.GetComponent<ClassUnite>().PrendreDegat(degat);

    }

    public void takeDmgFromTank(int tankDef)
    {
        int degatDefinitif = unite.GetAttaque() + tankDef;

        if (degatDefinitif > unite.GetDefence())
        {
            unite.SetPointDeVie((unite.GetPointDeVie() - unite.GetAttaque() - tankDef) + unite.GetDefence());
        }
    }
    // GETTEUR 

    public ClassUnite GetUnite()
    {
        return unite;
    }

    // ---------- //


    public void TakeDegat(int attaqueEnnemie)
    {
        int damage = attaqueEnnemie - unite.GetDefence();
        unite.SetPointDeVie(unite.GetPointDeVie() - damage);
        if (unite.GetPointDeVie() <= 0)
        {
            GameManager.MonstreMeure(unite.getLevel());
            Destroy(gameObject);
        }
    }

    public void BeTaunt()
    {
        taunted = true;
    }

    /* Collision avec evironement */

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<ScriptMouvementNPC>() || collision.gameObject.GetComponent<MovementPlayer>())
        {
            // ATTAQUER
            Debug.Log("J'ai toucher la bonne cible");
        }
        if (collision.gameObject.GetComponent<ProjectilleScript>())
        {
            TakeDegat(collision.gameObject.GetComponent<ProjectilleScript>().GetAttaque());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.GetComponent<ScriptPiege>()) 
        {
            TakeDegat(collision.gameObject.GetComponent<ScriptPiege>().GetAtq());
            Destroy(collision.gameObject);
        }
    }

    public void GainExperience(int nombredXP)
    {
        if (unite.LevelUp(nombredXP))
        {

            unite.SetAttaque(unite.GetAttaque() + Random.Range(1, 3));
            unite.SetDefence(unite.GetDefence() + Random.Range(1, 3));
            unite.SetMaxPointDeVie(unite.GetMaxPointDeVie() + Random.Range(3, 5));
            unite.SetMouvementVitesse(unite.GetMouvemenetVitesse() + Random.Range(1, 3));
            unite.SetVitesseAttaque(unite.GetVitesseAttaque() + Random.Range(1, 3));
        }
    }


}
