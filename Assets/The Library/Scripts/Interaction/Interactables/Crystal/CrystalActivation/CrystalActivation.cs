using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalActivation : Activatable
{
    [SerializeField] private List<GameObject> GameObjectsToActivate;

    public override void Activate()
    {
        foreach (var gameobject in GameObjectsToActivate)
            gameobject.SetActive(true);
    }
}
