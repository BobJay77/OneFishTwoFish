using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JohnStairs.RCC.Character;

public class DoesSomething : MonoBehaviour
{
    [SerializeField] public ICharacterInfo characterInfo;

    // Update is called once per frame
    void Update()
    {
        characterInfo = GetComponent<ICharacterInfo>();
        
    }
}
