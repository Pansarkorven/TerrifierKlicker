using UnityEngine;
using System.Collections.Generic;

public class SkinManager : MonoBehaviour
{
    public List<int> skinUnlockThresholds = new List<int> { 100, 500, 1000, 5000, 10000 };
    public List<GameObject> skins;

    private int currentSkinIndex = 0;

    
    void Start()
    {

        if (skins.Count > 0)
        {
            SetActiveSkin(0); 
            Debug.Log("Base skin (skin 0) activated at the start of the game.");
        }
        else
        {
            Debug.LogWarning("No skins are assigned to the SkinManager.");
        }
    }

    public void CheckForSkinUnlock(int killCount)
    {
        Debug.Log($"Checking for skin unlock. Current kill count: {killCount}, current skin index: {currentSkinIndex}");

        if (currentSkinIndex < skinUnlockThresholds.Count && killCount >= skinUnlockThresholds[currentSkinIndex])
        {
            Debug.Log($"Unlocking skin. Kill count ({killCount}) has reached the threshold for skin index {currentSkinIndex}.");
            UnlockNextSkin();
        }
        else
        {
            Debug.Log($"No skin to unlock yet. Next unlock at {skinUnlockThresholds[currentSkinIndex]} kills.");
        }
    }

    private void UnlockNextSkin()
    {
        currentSkinIndex++;
        if (currentSkinIndex < skins.Count)
        {
            Debug.Log($"Unlocking next skin. Setting skin index {currentSkinIndex} active.");
            SetActiveSkin(currentSkinIndex);
        }
        else
        {
            Debug.LogWarning("No more skins to unlock. All skins have been unlocked.");
        }
    }

    private void SetActiveSkin(int index)
    {
        Debug.Log($"Activating skin index: {index}");

        for (int i = 0; i < skins.Count; i++)
        {
            bool isActive = (i == index);
            skins[i].SetActive(isActive);

            Debug.Log($"Skin {i} active: {isActive}");
        }

        Debug.Log($"Skin {index} has been set active.");
    }
}
