using UnityEngine;
using System.Collections.Generic;

public class SkinManager : MonoBehaviour
{
   
    public List<int> skinUnlockThresholds = new List<int> { 100, 500, 1000, 5000, 10000 };

    
    public List<GameObject> skins;

    private int currentSkinIndex = 0; 

    
    public void CheckForSkinUnlock(int killCount)
    {
        if (currentSkinIndex < skinUnlockThresholds.Count && killCount >= skinUnlockThresholds[currentSkinIndex])
        {
            UnlockNextSkin();
        }
    }

    
    private void UnlockNextSkin()
    {
        currentSkinIndex++;
        if (currentSkinIndex < skins.Count)
        {
            SetActiveSkin(currentSkinIndex);
        }
        else
        {
            Debug.LogWarning("No more skins to unlock!");
        }
    }

    
    private void SetActiveSkin(int index)
    {
        for (int i = 0; i < skins.Count; i++)
        {
            skins[i].SetActive(i == index);
        }
        Debug.Log($"Unlocked new skin: {index}");
    }
}
