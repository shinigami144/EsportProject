using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDps : MonoBehaviour
{

    private ClassUnite unite;
    public float fireRate;
    public float atq;
    private float pvCible;
    private Vector3 positionExpediteur;
    private Vector3 positionDestinataire;
    public GameObject projectile;
    private Vector3 trajectoire;


    private void Tirer(GameObject expediteur, GameObject destinataire,GameObject balle)     //Fonction créé une trajectoire de tire  
    {                                                                                       //et instantie un projectile sur        Vector3 trajectoire;
        positionExpediteur = expediteur.transform.position;                                 //la trajectoire
        positionDestinataire = destinataire.GetComponent<ScriptMonstre>().GetCible();

        trajectoire.x = positionDestinataire.x - positionExpediteur.x;
        trajectoire.y = positionDestinataire.y - positionExpediteur.y;
        trajectoire.z = positionDestinataire.z - positionExpediteur.z;

        projectile=Instantiate(balle, new Vector3(positionDestinataire.x, positionDestinataire.y, positionDestinataire.z), Quaternion.identity);
        projectile.GetComponent<Rigidbody>().AddForce(trajectoire);
    }
}
