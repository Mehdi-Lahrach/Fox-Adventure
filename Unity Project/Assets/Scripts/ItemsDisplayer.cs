
using UnityEngine;
using UnityEngine.UI;

public class ItemsDisplayer : MonoBehaviour
{
    public int gemsCounter = 0;
    public int cherryCounter = 0;
    public int keyCounter = 0;
    public Text gemText;
    public Text cherryText;
    public Text keyText;
    public void DisplayGems()
    {
        gemText.text = "X " + gemsCounter;
    }       
         
    public void DisplayCherry()
    {
        cherryText.text = "X " + cherryCounter;
    }
    public void DisplayKey()
    {
        keyText.text = "X " + keyCounter;
    }
}
