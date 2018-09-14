using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadioButtonManager : MonoBehaviour
{

    public Toggle[] group;
    private string currentDifficulty = "Easy";

    public void PrintNewGroupValue(Toggle sender)
    {
        // only take notice from Toggle just swtiched to On
        if (sender.isOn)
        {
            foreach (Toggle toggle in group)
            {
                if (!toggle.tag.Equals(sender.tag)) toggle.isOn = false;
            }
            currentDifficulty = sender.tag;
            print("option changed to = " + currentDifficulty);
        }
    }
}
