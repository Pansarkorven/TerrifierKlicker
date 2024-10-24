using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite skin0;    // Skin for 0 kills
    public Sprite skin100;  // Skin for 100 kills
    public Sprite skin500;  // Skin for 500 kills
    public Sprite skin1000; // Skin for 1000 kills
    public Image skinImage; // The UI Image to display the skin

    private int currentSkinLevel = -1;  // Tracks the current skin level (-1 indicates no skin unlocked yet)

    void Start()
    {
        // Initially, show the default skin for 0 kills
        if (skinImage != null)
        {
            skinImage.sprite = skin0; // Display the initial skin for 0 kills
            currentSkinLevel = 0;
            Debug.Log("SkinManager: Initialized with skin0 for 0 kills.");
        }
        else
        {
            Debug.LogWarning("SkinManager: Skin Image component is not assigned.");
        }
    }

    // This method is called from the CookieGameScript, passing in the player's total kills (KillsEverGotten)
    public void CheckForSkinUnlock(int killsEverGotten)
    {
        // Log the current kills for debugging
        Debug.Log($"SkinManager: Checking for skin unlock. KillsEverGotten: {killsEverGotten}, Current Skin Level: {currentSkinLevel}");

        // Check for specific kill thresholds and assign the corresponding skin only if a new threshold is reached
        if (killsEverGotten >= 1000 && currentSkinLevel < 3)
        {
            UnlockSkin(skin1000, 3); // Show skin for 1000 kills and set skin level to 3
        }
        else if (killsEverGotten >= 500 && currentSkinLevel < 2)
        {
            UnlockSkin(skin500, 2); // Show skin for 500 kills and set skin level to 2
        }
        else if (killsEverGotten >= 100 && currentSkinLevel < 1)
        {
            UnlockSkin(skin100, 1); // Show skin for 100 kills and set skin level to 1
        }
        else if (killsEverGotten < 100 && currentSkinLevel != 0)
        {
            UnlockSkin(skin0, 0); // Show skin for 0 kills and set skin level to 0
        }
    }

    // Method to assign the skin sprite to the Image component and update the skin level
    private void UnlockSkin(Sprite skin, int newSkinLevel)
    {
        if (skin != null && skinImage != null)
        {
            skinImage.sprite = skin; // Update the skin image to the passed sprite
            currentSkinLevel = newSkinLevel; // Update the skin level
            Debug.Log($"SkinManager: Skin updated to {skin.name}, New Skin Level: {currentSkinLevel}");
        }
        else
        {
            Debug.LogError("SkinManager: Invalid skin or skinImage not assigned.");
        }
    }
}
