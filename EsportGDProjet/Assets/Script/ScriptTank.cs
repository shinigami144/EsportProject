using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTank : MonoBehaviour
{
    private int distDeTaunt = 10;
    private ClassUnite unite;
    private void Start()
    {
        unite = new ClassUnite();
    }
    //fonction qui renvoie les dégats
    public void defenseEpineuse(ScriptMonstre monstre)
    {
        monstre.takeDmgFromTank(unite.GetDefence());
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
    public void Taunt(ScriptMonstre monstre)
    {
        if (Vector3.Distance(this.transform.position, monstre.transform.position) < distDeTaunt)
        {
            monstre.GetUnite().SetCibleObjet(gameObject);
        }
    }
}