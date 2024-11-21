using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int bloodCost, woodCost, crystalCost;

    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceManager.instance.blood < bloodCost || ResourceManager.instance.wood < woodCost || ResourceManager.instance.crystal < crystalCost){
            button.interactable = false;
        } else {
            button.interactable = true;
        }
    }

    public void RemoveResources(){
        ResourceManager.instance.AddResource("Blood", -bloodCost);
        ResourceManager.instance.AddResource("Wood", -woodCost);
        ResourceManager.instance.AddResource("Crystal", -crystalCost);
    }
}
