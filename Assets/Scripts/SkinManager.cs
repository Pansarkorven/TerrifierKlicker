using UnityEngine;
using System.Collections.Generic;

public class SkinManager : MonoBehaviour
{
    public List<int> skinUnlockThresholds = new List<int> { 100, 500, 1000, 5000, 10000 };
    public List<GameObject> skinPrefabs;

    private GameObject currentSkin;
    private int currentSkinIndex = 0;

    void Start()
    {
        if (skinPrefabs.Count > 0)
        {
            SpawnSkin(0);
        }
        else
        {
            Debug.LogWarning("No skins are assigned to the SkinManager.");
        }
    }

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

        if (currentSkinIndex < skinPrefabs.Count)
        {
            if (currentSkin != null)
            {
                Destroy(currentSkin);
            }

            SpawnSkin(currentSkinIndex);
        }
        else
        {
            Debug.LogWarning("No more skins to unlock. All skins have been unlocked.");
        }
    }

    private void SpawnSkin(int index)
    {
        currentSkin = Instantiate(skinPrefabs[index], transform.position, transform.rotation);
    }
}
