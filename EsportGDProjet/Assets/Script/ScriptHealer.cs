using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHealer : MonoBehaviour
{
    // Start is called before the first frame update
    ClassUnite unite;
    ScriptGameManager gm;

    public GameObject piege;
    void Start()
    {
        unite = new ClassUnite("Hero",85,15,5,8,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainExperience(int nombredXP)
    {
        if (unite.LevelUp(nombredXP))
        {

            unite.SetAttaque(unite.GetAttaque() + Random.Range(0, 2));
            unite.SetDefence(unite.GetDefence() + Random.Range(1, 3));
            unite.SetMaxPointDeVie(unite.GetMaxPointDeVie() + Random.Range(3, 5));
            unite.SetMouvementVitesse(unite.GetMouvemenetVitesse() + Random.Range(3, 4));
            unite.SetVitesseAttaque(unite.GetVitesseAttaque() + Random.Range(2, 4));
        }
    }

    public void PoserPiege(Vector3 ouPoser)
    {
        GameObject p = Instantiate(piege);
        p.transform.position = ouPoser+new Vector3(0,1,0);   
    }

    public void Heal(GameObject cible)
    {
        if (cible.GetComponent<ScriptDps>() != null)
        { // dps
            cible.GetComponent<ScriptDps>();
        }
        else if (cible.GetComponent<ScriptTank>() != null)
        { // tank
            cible.GetComponent<ScriptTank>();
        }
        else
        { //  healer
            cible.GetComponent<ScriptHealer>().getHeal(unite.GetAttaque());
        }
    }

    public void PrendreDegat(int attaqueEnnemi)
    {
        int degat = attaqueEnnemi - unite.GetDefence();
        if (!unite.PrendreDegat(degat))
        {
            if (GetComponent<ScriptMouvementNPC>())
            {
                // supprimer de la liste 
                Destroy(this);
            }
            else if (GetComponent<MovementPlayer>())
            {
                // GAME  OVER
            }
        }

    }

    public void GetHeal(int soinValeur)
    {
        unite.SetPointDeVie(unite.GetPointDeVie() + soinValeur);
    }


}
