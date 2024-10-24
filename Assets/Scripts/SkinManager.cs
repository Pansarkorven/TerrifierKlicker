using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite skin0;    // Skin for 0 kills
    public Sprite skin100;  // Skin for 100 kills
    public Sprite skin500;  // Skin for 500 kills
    public Sprite skin1000; // Skin for 1000 kills
    public Image skinImage; // The UI Image to display the skin

    private int currentSkinLevel = 0;  // Tracks the current skin level (0 = skin0, 1 = skin100, 2 = skin500, 3 = skin1000)

    void Start()
    {
        // Initially, show the default skin for 0 kills
        if (skinImage != null)
        {
            skinImage.sprite = skin0; // Display the initial skin for 0 kills
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
        Debug.Log("SkinManager: Checking for skin unlock. KillsEverGotten: " + killsEverGotten);

        // Check for specific kill thresholds and assign the corresponding skin only if a new threshold is reached
        if (killsEverGotten >= 1000 && currentSkinLevel < 3)
        {
            UnlockSkin(skin1000); // Show skin for 1000 kills
            currentSkinLevel = 3; // Update the current skin level to 3
        }
        else if (killsEverGotten >= 500 && currentSkinLevel < 2)
        {
            UnlockSkin(skin500); // Show skin for 500 kills
            currentSkinLevel = 2; // Update the current skin level to 2
        }
        else if (killsEverGotten >= 100 && currentSkinLevel < 1)
        {
            UnlockSkin(skin100); // Show skin for 100 kills
            currentSkinLevel = 1; // Update the current skin level to 1
        }
        else if (killsEverGotten < 100 && currentSkinLevel == 0)
        {
            UnlockSkin(skin0); // Show skin for 0 kills if no thresholds have been reached
        }
    }

    // Method to assign the skin sprite to the Image component
    private void UnlockSkin(Sprite skin)
    {
        if (skin != null && skinImage != null)
        {
            skinImage.sprite = skin; // Update the skin image to the passed sprite
            Debug.Log("SkinManager: Skin updated to: " + skin.name);
        }
        else
        {
            Debug.LogError("SkinManager: Invalid skin or skinImage not assigned.");
        }
    }
}
