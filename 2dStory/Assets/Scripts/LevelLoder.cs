using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoder : MonoBehaviour
{
    private bool[] allKeyPressed = new bool[7];
    
    void Update()
    {
   
            for (int i = 0; i <= 7; i++)
            {
                if(Input.GetKeyDown(KeyCode.Alpha0 +i))
                {
                    allKeyPressed[i-1] = true;
                }
            }

            if (canLoad())
            {
                SceneManager.LoadScene(1);
            }
  
    }

    private bool canLoad()
    {
        foreach (bool pressed in allKeyPressed)
        {
            if (!pressed) return false;
        }

        return true;
    }
}
