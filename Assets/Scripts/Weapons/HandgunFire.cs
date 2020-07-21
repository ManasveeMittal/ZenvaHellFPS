﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{

    public GameObject theGun;
    //public GameObject muzzleFlash;
    public AudioSource gunFireFX;
    public AudioSource emptyAmmoFX;
    public bool isFiring = false;
    public int damageAmount = 5;
    public float targetDistance;

    void Update()
    {
        // fire on left-mouse-key press
        if (Input.GetButtonDown("Fire1"))
        {
            if (GlobalStats.magazineAmmo < 1)
            {
                emptyAmmoFX.Play();
            }
            else
            {
                //wait for last firing to end
                if (isFiring == false)
                {
                    StartCoroutine(FireHandgun());
                }
            }
        }
    }

    void OnFireButtonPress()
    {
        if (GlobalStats.magazineAmmo < 1)
        {
            emptyAmmoFX.Play();
        }
        else
        {
            //wait for last firing to end
            if (isFiring == false)
            {
                StartCoroutine(FireHandgun());
            }
        }
    }

    IEnumerator FireHandgun()
        {
            //set firing status to true
            //play gun cocking animation
            //play muzzle flash
            //play firing sound
            //reset everything

            RaycastHit gunShot;
            isFiring = true;
            GlobalStats.ammoCount -= 1;
            GlobalStats.magazineAmmo -= 1;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out gunShot))
            {
                targetDistance = gunShot.distance;
                gunShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
            }
            theGun.GetComponent<Animator>().Play("FPSHand|Fire");
            //muzzleFlash.SetActive(true);
            gunFireFX.Play();
            yield return new WaitForSeconds(0.05f);
            //muzzleFlash.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            theGun.GetComponent<Animator>().Play("FPSHand|Stand");
            isFiring = false;
        }
 }

