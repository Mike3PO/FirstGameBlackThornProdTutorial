using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public Ghost worker, village, tree, crystal, trap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopClick(string item){
        if(item == "worker"){
            Instantiate(worker);
        } else if(item == "village"){
            Instantiate(village);
        } else if(item == "tree"){
            Instantiate(tree);
        } else if(item == "crystal"){
            Instantiate(crystal);
        } else if(item == "trap"){
            Instantiate(trap);
        }
    }
}
