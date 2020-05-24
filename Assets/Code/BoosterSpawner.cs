using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    public List<Transform> boostersSpawnPosition;
    public List<GameObject> boostersPrefabs;
    [SerializeField] float spawnCooldown;
    [SerializeField] float boosterAppearProb;
    CoolDownHability cooldown;

    public System.Action SpeedBoosterTouched;
    public System.Action HeartBoosterTouched;
    public System.Action BombBoosterTouched;


    private void Start()
    {
      //  InvokeRepeating("CheckAndSpawnBooster",1f,spawnCooldown);
    }

    void CheckAndSpawnBooster()
    {
        int rand = Random.Range(1, 100);
        if (rand < boosterAppearProb)
        {
            Random.seed = (int)System.DateTime.Now.Ticks;
            Booster booster = Instantiate(boostersPrefabs[Random.Range(0, boostersPrefabs.Count)], boostersSpawnPosition[Random.Range(0, boostersSpawnPosition.Count)]).GetComponent<Booster>();
            booster.BoosterTouched += OnBoosterTouched;
        }
    }

    private void OnBoosterTouched(Booster booster)
    {
        if (booster)
        {
            booster.BoosterTouched -= OnBoosterTouched;

            switch (booster.boosterId)
            {
                case 1:
                    if (SpeedBoosterTouched != null)
                    {
                        SpeedBoosterTouched();
                    }
                    break;
                case 2:
                    if (HeartBoosterTouched != null)
                    {
                        HeartBoosterTouched();
                    }
                    break;
                case 3:
                    if (BombBoosterTouched != null)
                    {
                        BombBoosterTouched();
                    }
                    break;
            }
        }
    }
}
