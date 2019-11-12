using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMonstre : MonoBehaviour
{
    // Start is called before the first frame update
    ClassUnite unite;
    int timeur;
    void Start()
    {
        timeur = 0;
        unite = new ClassUnite();
        //unite.SetCible(GetComponent<ScriptCiblageAutre>().TrouvePositonCible());
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

        if(unite.GetCibleObjet().GetComponent<ScriptDps>() != null)
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






    // GETTEUR 

    public ClassUnite GetUnite()
    {
        return unite;
    }

    // ----------

    
    public void TakeDegat(int attaqueEnnemie)
    {
        int damage = attaqueEnnemie - unite.GetDefence();
        unite.SetPointDeVie(unite.GetPointDeVie() - damage);
        if(unite.GetPointDeVie() <= 0)
        {
            Destroy(gameObject);
        }
    }

    /* Collision avec evironement */

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == unite.GetCibleObjet())
        {
            // ATTAQUER
            Debug.Log("J'ai toucher la bonne cible");
        }
        if(collision.gameObject.GetComponent<ProjectilleScript>())
        {
            TakeDegat(collision.gameObject.GetComponent<ProjectilleScript>().GetAttaque());
            Destroy(collision.gameObject);
        }
    }
    /*
    private void OnCollisionStay(Collision collision)
    {
        /* EXTREMEMENT RAPIDE !!! TROUVER MOYEN DE REDUIRE LA VITESSE *\/
        if (collision.gameObject == unite.GetCibleObjet())
        {
            Debug.Log("DA : Test Reduction Temps");
            if (timeur % 60 == 0)
            {
                timeur = 0;
                Attaquer();
            }
            timeur += unite.GetVitesseAttaque() + 1;
        }
        //Debug.Log(collision.gameObject);
    }*/

    /*--------------------------------*/

}
