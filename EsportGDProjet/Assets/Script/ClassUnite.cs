using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUnite
{
    private int pointDeVie;
    private int maxPointDeVie;
    private string nom;
    private GameObject cibleObjet;
    private Vector3 cible;
    private int attaque;
    private int defence;
    private int mouvementVitesse;
    private int vitesseAttaque;
    private int xp;
    private int xpPourNiveauSuivant;
    private int level;

    public bool PrendreDegat(int degat)
    {
        bool enVie = true;
        pointDeVie -= degat;
        if(pointDeVie <= 0)
        {
            enVie = false;
        }
        return enVie;
    }

    private void LevelUp()
    {
        if(xp >= xpPourNiveauSuivant)
        {
            level++;
        }
        xp -= xpPourNiveauSuivant;
        xpPourNiveauSuivant += xpPourNiveauSuivant * 2;
    }

    public void XpGain(int value)
    {
        xp += value;
        LevelUp();
    }

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

    public GameObject GetCibleObjet()
    {
        return cibleObjet;
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
    public int GetVitesseAttaque()
    {
        return vitesseAttaque;
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

    public void SetCibleObjet(GameObject gameObject)
    {
        cibleObjet = gameObject;
        cible = gameObject.transform.position;
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

    public void SetVitesseAttaque(int _vitesseAttaque)
    {
        this.vitesseAttaque = _vitesseAttaque;
    }

    //-----//
    // Constructeur

    public ClassUnite() : this("Inconu",0,0,0,0,0)
    {

    }

    public ClassUnite(string _nom,int _MaxPointDeVie,int _attaque,int _defence,int _vitesseAttaque,int _mouvementVitesse)
    {
        nom = _nom;
        maxPointDeVie = _MaxPointDeVie;
        attaque = _attaque;
        defence = _defence;
        mouvementVitesse = _mouvementVitesse;
        cible = new Vector3(0,0,0);
        vitesseAttaque = _vitesseAttaque;
    }

    public ClassUnite(string _nom) : this(_nom, 0, 0,0, 0, 0)
    {

    }
    // ----- // 

}
