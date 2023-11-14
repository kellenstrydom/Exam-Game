using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class EskomHub : MonoBehaviour
{

    public static List<string> sceneNameInorder = new List<string>()
    {
        "City 1",
        "city 2",
        "Diepsloot",
        "City 3",
        "S"
    };
    
    public static List<bool> DoorsOpen = new List<bool>(){true, false, false, false, false};



    public void GoToScene(int index)
    {
        if (DoorsOpen[index])
        {
            // test------------------------------------------
            
            CompleteScene(index);

            //test---------------------------------------------
            
            //SceneManager.LoadScene(sceneNameInorder[index]);
        }
    }

    public static void CompleteScene(int index)
    {
        EskomHub.DoorsOpen[index + 1] = true;
    }
}
