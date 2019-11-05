using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUnite
{
    private int pointDeVie;
    private int maxPointDeVie;
    private string nom;
    private GameObject cible;
    private int attaque;
    private int defence;
    private int mouvementVitesse;


    // GETTEUR
    public int GetPointDeVie()
    {
        return pointDeVie;
    }

    public int GetMaxPointDeVie()
    {
        return maxPointDeVie;
    }

    public string GetNom()
    {
        return nom;
    }

    public GameObject GetCible()
    {
        return cible;
    }

    public int GetAttaque()
    {
        return attaque;
    }

    public int GetDefence()
    {
        return defence;
    }
    
    public int GetMouvemenetVitesse()
    {
        return mouvementVitesse;
    }
    //-------//
    // SETTEUR

    public void SetPointDeVie(int nouveauPointDeVie)
    {
        pointDeVie = nouveauPointDeVie;
    }

    public void SetMaxPointDeVie(int nouveauMaxPointDeVie)
    {
        maxPointDeVie = nouveauMaxPointDeVie;
    }

    public void SetNom(string nouveauNom)
    {
        nom = nouveauNom;
    }

    public void SetCible(GameObject theCible)
    {
        cible = theCible;
    }

    public void SetAttaque(int nouvelleAttaque)
    {
        attaque = nouvelleAttaque;
    }

    public void SetDefence(int nouvelleDefence)
    {
        defence = nouvelleDefence;
    }

    public void SetMouvementVitesse(int mouvementVitesse)
    {
        this.mouvementVitesse = mouvementVitesse;
    }

    //-----//
    // Constructeur

    ClassUnite() : this("Inconu",0,0,0,0)
    {

    }

    ClassUnite(string _nom,int _MaxPointDeVie,int _attaque,int _defence,int _mouvementVitesse)
    {
        nom = _nom;
        maxPointDeVie = _MaxPointDeVie;
        attaque = _attaque;
        defence = _defence;
        mouvementVitesse = _mouvementVitesse;
        cible = null;
    }

    ClassUnite(string _nom) : this(_nom, 0, 0, 0, 0)
    {

    }
    // ----- // 
    // fonction utilitaire 

    private void ReceiveDmg(GameObject cible)
    {
        this.pointDeVie -= cible.GetComponent<ScriptMonstre>().GetAttaque();
    }

    // ----- //
}
