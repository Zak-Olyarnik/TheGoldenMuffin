using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private RectTransform winEffect = default;     // reference to win effect animated component
    [SerializeField] private Text bestTimeText = default;           // reference to best time UI
    [SerializeField] private GameObject[] storyScreens = default;   // reference to the list of menu screens leading into the game

    private readonly float winEffectSpeed = 1.5f;   // speed of win effect rotation animation


    // Display best time UI
    private void OnEnable()
    {
        DarkMagician.BestTime = PlayerPrefs.GetInt("BestTime", 0);

        if (DarkMagician.BestTime == 0)
            bestTimeText.text = "????";
        else
            bestTimeText.text = DarkMagician.TimeString(DarkMagician.BestTime);
    }

    // Win effect rotation animation
    private void FixedUpdate()
    {
        winEffect.Rotate(new Vector3(0, 0, winEffectSpeed));
    }

    // Advance to next screen (when UI button is clicked)
    public void Advance(int in_index)
    {
        if (in_index == 3)
            SceneManager.LoadScene("Main");
        else
            storyScreens[in_index].SetActive(true);
    }
}
