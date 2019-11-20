using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour
{
    [SerializeField] private RectTransform winEffect = default;     // reference to win effect animated component
    [SerializeField] private Text lastTimeText = default;           // reference to last time UI
    [SerializeField] private Text bestTimeText = default;           // reference to best time UI

    private readonly float winEffectSpeed = 1.5f;   // speed of win effect rotation animation
    private readonly float loadDelay = 12f;         // duration to display win screen before returning to main menu


    private void OnEnable()
    {
        // Update best time
        if(DarkMagician.BestTime == 0 || DarkMagician.Clock < DarkMagician.BestTime)
        {
            DarkMagician.BestTime = DarkMagician.Clock;
            PlayerPrefs.SetInt("BestTime", DarkMagician.BestTime);
            PlayerPrefs.Save();
        }

        // Display last and best time UI
        lastTimeText.text = DarkMagician.TimeString(DarkMagician.Clock);
        bestTimeText.text = DarkMagician.TimeString(DarkMagician.BestTime);

        // Move back to menu automatically
        Invoke("LoadMenu", loadDelay);
    }

    // Win effect rotation animation
    private void FixedUpdate()
    {
        winEffect.Rotate(new Vector3(0, 0, winEffectSpeed));
    }

    // Return to main menu
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
