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
    void Start()
    {
        List<int> lstat = new List<int>();
        timeur = 0;
        unite = new ClassUnite("Monstre" + NUMBER_MONSTER.ToString(), 75, 25, 5, 5, 3);
        NUMBER_MONSTER++;
        GameManager = FindObjectOfType<ScriptGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        unite.SetCibleObjet(GetComponent<ScriptCiblageAutre>().TrouverCible());
        unite.SetCible(unite.GetCibleObjet().transform.position);
        Debug.Log(unite.GetCibleObjet());
    }

    public void Attaquer()
    {

        if (unite.GetCibleObjet().GetComponent<ScriptDps>() != null)
        { // dps
            unite.GetCibleObjet().GetComponent<ScriptDps>();
        }
        else if (unite.GetCibleObjet().GetComponent<ScriptTank>() != null)
        { // tank
            unite.GetCibleObjet().GetComponent<ScriptTank>();
        }
        else
        { //  healer
            unite.GetCibleObjet().GetComponent<ScriptHealer>().PrendreDegat(unite.GetAttaque());
        }
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

    /* Collision avec evironement */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == unite.GetCibleObjet())
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
