using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDps : MonoBehaviour
{

    private ClassUnite unite;
    public GameObject projectile;


    private void Start()
    {
        unite = new ClassUnite("Hero", 100, 30,5,15,5); 
    }

    public void GainExperience(int nombredXP)
    {
        if (unite.LevelUp(nombredXP))
        {

            unite.SetAttaque(unite.GetAttaque() + Random.Range(2, 5));
            unite.SetDefence(unite.GetDefence() + Random.Range(0, 2));
            unite.SetMaxPointDeVie(unite.GetMaxPointDeVie() + Random.Range(3, 5));
            unite.SetMouvementVitesse(unite.GetMouvemenetVitesse() + Random.Range(2, 4));
            unite.SetVitesseAttaque(unite.GetVitesseAttaque() + Random.Range(2, 5));
        }
    }

    public void Tirer(Vector3 ouTirer)
    {
        //TODO : calculer avec exactitude l'emplacement de projectille : entre -1,0.5,-1 et 1,0.5f,1;
        Vector3 _direction = new Vector3(0, 0, 0);
        for(int i = 0;i< 3; i++) {
            if(ouTirer[i] > transform.position[i])
            {
                _direction[i] = 1;
            }
            else if (ouTirer[i] < transform.position[i])
            {
                _direction[i] = -1;
            }
            else
            {
                _direction[i] = 0;
            }
        }
        _direction.y = 0.5f;
        Vector3 force = transform.position;
        force.y = 0;
        GameObject p = Instantiate(projectile);
        p.transform.position = force + _direction;
        p.GetComponent<ProjectilleScript>().SetAttaque(unite.GetAttaque());
        force = new Vector3(ouTirer.x - transform.position.x, 0, ouTirer.z - transform.position.z);
        p.GetComponent<Rigidbody>().AddForce((ouTirer-transform.position)*50); // reduction au pgcd pour eviter les difference de pousser
        
    }
}
