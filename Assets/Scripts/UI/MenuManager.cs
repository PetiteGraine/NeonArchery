using UnityEngine;
using UnityEditor;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI handPreference;
    [SerializeField] private TextMeshProUGUI turnMode;
    [SerializeField] private TextMeshProUGUI timeLimitMode;

    public void ChangeHandPref()
    {
        if (handPreference.text == "Right Handed")
            handPreference.text = "Left Handed";
        else if (handPreference.text == "Left Handed")
            handPreference.text = "Right Handed";
    }

    public void ChangeTurnMode()
    {
        if (turnMode.text == "Snap Turn")
            turnMode.text = "Smooth Turn";
        else if (turnMode.text == "Smooth Turn")
            turnMode.text = "Snap Turn";
    }
    public void ChangeTimeLimitMode()
    {
        if (timeLimitMode.text == "Limited Time")
            timeLimitMode.text = "Unlimited Time";
        else if (timeLimitMode.text == "Unlimited Time")
            timeLimitMode.text = "Limited Time";
    }

    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
