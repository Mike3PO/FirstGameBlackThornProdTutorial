using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{

    public int wood;
    public int blood;
    public int crystal;
    public static ResourceManager instance;
    public TMP_Text woodDisplay;
    public TMP_Text bloodDisplay;
    public TMP_Text crystalDisplay;

    public int numberOfWorkersSacrificed;
    public TMP_Text sacrificedWorkersText;
    public int sacrificeGoal;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(string resourceType, int amount){
        if(resourceType == "Wood"){
            wood += amount;
            woodDisplay.text = wood.ToString();
        } else if(resourceType == "Blood"){
            blood += amount;
            bloodDisplay.text = blood.ToString();
        } else if(resourceType == "Crystal"){
            crystal += amount;
            crystalDisplay.text = crystal.ToString();
        }
    }

    public void AddSacrificedWorker(){
        numberOfWorkersSacrificed++;
        sacrificedWorkersText.text = numberOfWorkersSacrificed.ToString() + " / " + sacrificeGoal;
        if(numberOfWorkersSacrificed >= sacrificeGoal){
            SceneManager.LoadScene("Win Screen");
            print("YOU HAVE WON!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
