using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DLS.Description;
using UnityEngine;

namespace Game.ModLoader.Types
{
  
  public abstract class Mod
  {
    public List<ModChip> chips { get; private set; } = new List<ModChip>();
    public virtual void OnLoad() {}

    public void RegisterChip(ModChip chip)
    {
      Debug.Log($"[{GetType().Name}]: Registering Chip: {chip.ChipName}");
      chips.Add(chip);
    }
    public virtual void OnLoadComplete() {}
    
    public virtual void OnUnload() {}
    
  }
}