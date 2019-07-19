using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    
    public static void SetSave(float Value)
    {
        PlayerPrefs.SetFloat("BestScore" + 0 , Value);
    }
   
    public static float LoadSave()
    {
        return PlayerPrefs.GetFloat("BestScore" + 0);
    }

}
