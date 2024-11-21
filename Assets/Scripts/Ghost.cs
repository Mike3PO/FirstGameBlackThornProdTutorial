using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ghost : MonoBehaviour
{

    public GameObject objectToSpawn;
    private Animator camAnim;
    public GameObject buildEffect;
    public GameObject buildSound;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;
        transform.position = mousepos;

        if(Input.GetMouseButtonDown(0)){
            Instantiate(buildSound);
            Instantiate(buildEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
