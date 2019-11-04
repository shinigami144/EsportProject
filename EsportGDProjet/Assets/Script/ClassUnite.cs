using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUnite
{
    private int pointDeVie;
    private int maxPointDeVie;
    private string nom;
    //private GameObject cibleObjet;
    private Vector3 cible;
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

    public Vector3 GetCible()
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

    public void SetCible(Vector3 theCible)
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

    public ClassUnite() : this("Inconu",0,0,0,0)
    {

    }

    public ClassUnite(string _nom,int _MaxPointDeVie,int _attaque,int _defence,int _mouvementVitesse)
    {
        nom = _nom;
        maxPointDeVie = _MaxPointDeVie;
        attaque = _attaque;
        defence = _defence;
        mouvementVitesse = _mouvementVitesse;
        cible = new Vector3(0,0,0);
    }

    public ClassUnite(string _nom) : this(_nom, 0, 0, 0, 0)
    {

    }
    // ----- // 

}
