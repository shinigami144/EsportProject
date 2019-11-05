using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTank : MonoBehaviour
{
    public int distDeTaunt = 10;
    GameObject[] monstres = new GameObject[5];

    //Fonction qui renvoie les dégats
    public void DefenseEpineuse()
    {
        if (this.ReceivingDmg(monstre))
        {
            foreach(GameObject monstre.GetCible(this) in monstres){
                monstre.ReceiveDmg(this);
            }
        }
    }

    //Fonction qui taunt
    public void Taunt()
    {
        foreach(GameObject monstre in monstres){
            if (Vector3.Distance(this.transform.position,monstre.transform.position)<distDeTaunt)
            {
                monstre.SetCible(this);
            }
        }
    }
}
