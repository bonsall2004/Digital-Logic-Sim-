using System;
using UnityEngine.Scripting;

namespace Game.ModLoader.Types
{
  [AttributeUsage(AttributeTargets.Class)]
  [Preserve]
  public class ModCollection : Attribute
  {
    [Preserve]
    public string collectionName;
    [Preserve]
    public ModCollection(string collectionName)
    {
      this.collectionName = collectionName;
    }
  }
}