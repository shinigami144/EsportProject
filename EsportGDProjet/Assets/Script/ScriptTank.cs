using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTank : MonoBehaviour
{
    private int distDeTaunt = 10;
    private ClassUnite unite;
    private void Start()
    {
        unite = gameObject.AddComponent<ClassUnite>();
        unite.SetNom("Tank");
        unite.SetAttaque(20);
        unite.SetDefence(15);
        unite.SetMaxPointDeVie(105);
        unite.SetVitesseAttaque(4);
        unite.SetMouvementVitesse(5);
        SetMouvementSpeed();
        
    }
    //fonction qui renvoie les dégats
    public void defenseEpineuse(ScriptMonstre monstre)
    {
        monstre.takeDmgFromTank(unite.GetDefence());
    }

    public void SetMouvementSpeed()
    {
        if (GetComponent<MovementPlayer>())
        {
            GetComponent<MovementPlayer>().SetMouvementSpeed(unite.GetMouvemenetVitesse());
        }
        if (GetComponent<UnityEngine.AI.NavMeshAgent>())
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed = unite.GetMouvemenetVitesse();
        }
    }

    public void GainExperience(int nombredXP)
    {
        if (unite.LevelUp(nombredXP))
        {

            unite.SetAttaque(unite.GetAttaque() + Random.Range(0, 3));
            unite.SetDefence(unite.GetDefence() + Random.Range(3, 5));
            unite.SetMaxPointDeVie(unite.GetMaxPointDeVie() + Random.Range(4, 6));
            unite.SetMouvementVitesse(unite.GetMouvemenetVitesse() + Random.Range(0, 2));
            unite.SetVitesseAttaque(unite.GetVitesseAttaque() + Random.Range(0, 2));
        }
    }

    //fonction qui taunt
    public void Taunt(GameObject monstre)
    {
        ScriptMonstre  Sm = monstre.GetComponent<ScriptMonstre>();
        if (Sm)
        {
            Sm.BeTaunt();
            Sm.GetUnite().SetCibleObjet(gameObject);
            Sm.GetUnite().SetCible(gameObject.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ScriptMonstre>())
        {
            collision.gameObject.GetComponent<ScriptMonstre>().Attaquer(gameObject);
        }
    }

}