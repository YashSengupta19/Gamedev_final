using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputField inputField;
    
    public void ValidateInput(){
        string input=inputField.text;
        if(input=="swss"){
            Debug.Log("swss");
        }
        else{
            Debug.Log("Wrong");
        }
    }
}