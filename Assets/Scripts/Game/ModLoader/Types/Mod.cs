using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DLS.Description;
using UnityEngine;
using UnityEngine.Scripting;

namespace Game.ModLoader.Types
{
  
  [Preserve]
  public abstract class Mod
  {
    [Preserve]

    public Mod()
    {
      
    }
    [Preserve]

    public List<ModChip> chips { get; private set; } = new List<ModChip>();
    [Preserve]
    public virtual void OnLoad() {}

    [Preserve]
    public void RegisterChip(ModChip chip)
    {
      chips.Add(chip);
    }
    [Preserve]
    public virtual void OnLoadComplete() {}
    
    [Preserve]
    public virtual void OnUnload() {}
    
  }
}