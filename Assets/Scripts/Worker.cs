using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{

    bool isSelected;

    public LayerMask resourceLayer;
    public float collectDistance;
    Resource currentResource;
    public float timeBetweenCollects;
    private float nextCollectTime;
    public int collectAmount;

    public float distanceToAltar;
    
    GameObject bloodAltar;
    public GameObject resourcePopUp;
    AudioSource workerPop;
    public GameObject workerDrop;
    public GameObject resourcePopSound;
    public GameObject workerDeath;

    // Start is called before the first frame update
    void Start()
    {
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
        workerPop = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected){
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;
            transform.position = mousepos;
        } else {
            if(Vector3.Distance(transform.position, bloodAltar.transform.position) <= distanceToAltar){
                ResourceManager.instance.AddSacrificedWorker();
                Instantiate(workerDeath);
                Destroy(gameObject);
            }

            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if(col != null && currentResource == null){
                currentResource = col.GetComponent<Resource>();
            } else {
                currentResource = null;
            }
        }

        if(currentResource != null){
            if(Time.time > nextCollectTime){
                nextCollectTime = Time.time + timeBetweenCollects;
                ResourceManager.instance.AddResource(currentResource.resourceType, Math.Min(currentResource.resourceAmount, collectAmount));
                currentResource.resourceAmount -= Math.Min(currentResource.resourceAmount, collectAmount);
                Instantiate(resourcePopUp, new Vector3(transform.position.x, transform.position.y + 2, 0), Quaternion.identity);
                Instantiate(resourcePopSound);
            }
        }
    }

    private void OnMouseDown(){
        isSelected = true;
        workerPop.Play();
    }

    private void OnMouseUp(){
        Instantiate(workerDrop);
        isSelected = false;
    }
}
