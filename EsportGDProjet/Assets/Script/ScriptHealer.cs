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
        unite = gameObject.AddComponent<ClassUnite>();
        unite.SetNom(gameObject.name);
        unite.SetAttaque(15);
        unite.SetDefence(5);
        unite.SetMaxPointDeVie(85);
        unite.SetPointDeVie(40);
        unite.SetVitesseAttaque(8);
        unite.SetMouvementVitesse(10);
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
        //Debug.Log("HEAL");
        ClassUnite cibleUnite = cible.GetComponent<ClassUnite>();
        cibleUnite.SetPointDeVie(cibleUnite.GetPointDeVie()+unite.GetAttaque());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ScriptMonstre>())
        {
            collision.gameObject.GetComponent<ScriptMonstre>().Attaquer(gameObject);
        }
    }
}
