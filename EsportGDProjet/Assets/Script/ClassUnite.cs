using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUnite : MonoBehaviour
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
    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

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

    public bool LevelUp(int value)
    {
        bool levelUp = false;
        xp += value;
        if(xp> xpPourNiveauSuivant)
        {
            level++;
            xp -= xpPourNiveauSuivant;
            xpPourNiveauSuivant *= (maxPointDeVie * xpPourNiveauSuivant);
            levelUp =  true;
        }
        return levelUp;
        
        
    }

    public int GetXpNiveauSuivant()
    {
        return xpPourNiveauSuivant;
    }

    public int getLevel()
    {
        return level;
    }

    public int GetXp()
    {
        return xp;
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
        if(nouveauPointDeVie >= maxPointDeVie)
        {
            //Debug.Log("max Point de vie lol");
            pointDeVie = maxPointDeVie;
        }
        else
        {
            pointDeVie = nouveauPointDeVie;
        }
    }

    public void SetMaxPointDeVie(int nouveauMaxPointDeVie)
    {
        maxPointDeVie = nouveauMaxPointDeVie;
        pointDeVie = maxPointDeVie;
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

    public void CopyConstructor(ClassUnite u)
    {
        attaque = u.GetAttaque();
        maxPointDeVie = u.GetMaxPointDeVie();
        pointDeVie = u.GetPointDeVie();
        nom = u.GetNom();
        defence = u.GetDefence();
        vitesseAttaque = u.GetVitesseAttaque();
        xp = u.GetXp();
        mouvementVitesse = u.GetMouvemenetVitesse();
        level = u.getLevel();
        xpPourNiveauSuivant = u.GetXpNiveauSuivant();
    }

    // fonction utilitaire 


    // ----- //
}
