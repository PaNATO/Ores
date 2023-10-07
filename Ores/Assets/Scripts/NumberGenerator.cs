using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour
{
    public static NumberGenerator NumberGeneratorInstance;
    private void Awake()
    {
        if (NumberGeneratorInstance == null)
            NumberGeneratorInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class Numbers
    {
        public string Name;
        public int Number;
    }
    public List<Numbers> NumbersAm;

    public void NumberGeneratorA()
    {
        foreach(var elements in NumbersAm)
        {
            elements.Number = Random.Range(1, 100);
        }
    }
}
