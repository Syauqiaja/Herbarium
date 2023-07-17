using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Herbarium/Plant Data", fileName ="Plant Data")]
public class PlantData : ScriptableObject
{
    public string Title;
    public string Kingdom;
    public string Subkingdom;
    public string Superdivisi;
    public string Divisi;
    public string Kelas;
    public string Subkelas;
    public string Ordo;
    public string Subordo;
    public string Famili;
    public string Genus;
    public string Spesies;
}
