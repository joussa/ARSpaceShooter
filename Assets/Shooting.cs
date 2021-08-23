using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile; //préfab 

    private Camera cam; //camera

    public float speedProjectile; // vitesse des projectiles
    public float ShootRate; // nb de shoot
    private float LastTimeShoot; // LA dernière fois tirer

    public Object particle;

    private Vector3 position;// position projectile

    public static Shooting instance; // creation d'instance Shooting pour pouvoir y acceder n'importe où dans le porjet
    void Awake()
    {
       instance = this;
    }

    void Start()// obtenir la camera 
    {
        cam = Camera.main;
    }

    void Update()// détection quand on tape sur l'écran et envoyer le projectile
    {

        if (Input.touchCount > 0)// Sommes nous autorisé a tierr?
        {
            if(Time.time - LastTimeShoot >= ShootRate)
                Shoot();
        }
            /*     for (int i = 0; i < Input.touchCount; ++i)
                    {
                        if (Input.GetTouch(i).phase == TouchPhase.Began)
                        {
                            // Construct a ray from the current touch coordinates
                            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                            // Create a particle if hit
                            if (Physics.Raycast(ray))
                            {
                                Instantiate(particle, transform.position, transform.rotation);
                            }
                        }
                    }*/
            /*if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    projectile.SetActive(true);

                    Vector2 pos = touch.position;
                    position = new Vector3(-pos.x, pos.y, 0.0f);
                    transform.position = position;

                }

                if (touch.phase == TouchPhase.Ended)
                {

                }

            }
            if (Input.touchCount<0)
            {
                Touch touch = Input.GetTouch(0);
            }*/
        }
    void Shoot()
    {
        LastTimeShoot = Time.time;

        GameObject proj = Instantiate(projectile, cam.transform.position, Quaternion.identity);

        proj.GetComponent<Rigidbody>().velocity = cam.transform.forward * speedProjectile;
    }
}
