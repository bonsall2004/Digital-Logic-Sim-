using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DLS.Description;
using DLS.Description.Types;
using DLS.SaveSystem;
using DLS.Simulation;
using Game.ModLoader.Types;

namespace Game.ModLoader
{
  
  public interface IChipSim
  {
    public void Simulate(SimChip chip);
  }
  public class ModLoader
  {
    public static ModDescription[] activeModDescriptions;
    private static List<Mod> activeMods = new List<Mod>();

    public static ModChip[] ModdedChips
    {
      get;
      private set;
    }

    public static void CreateModdedChipDescriptions()
    {
      List<ModChip> modChips = new List<ModChip>();
      foreach (var mod in activeMods)
      {
        foreach (var chip in mod.chips)
        {
          if (chip == null) continue;
          chip.SetDefaults();
          chip.Chip.SubChips = Array.Empty<SubChipDescription>();
          chip.Chip.Wires = Array.Empty<WireDescription>();
          chip.Chip.ChipType = ChipType.Modded;
          modChips.Add(chip);
        }
      }

      ModdedChips = modChips.ToArray();
    }

    public static void Load()
    {
      foreach (var mod in activeMods)
      {
        mod.OnUnload();
      }
      activeMods.Clear();
      
      List<String> modAssemblies = new List<string>(); 
      foreach (var mod in activeModDescriptions)
      {
        string path = Path.Combine(SavePaths.ModDirectory, mod.ModName);
        if (Directory.Exists(Path.Combine(SavePaths.ModDirectory, mod.ModName)))
        {
          modAssemblies.AddRange(
            Directory.GetFiles(
              Path.Combine(SavePaths.ModDirectory, mod.ModName),
              "*.dll",
              SearchOption.TopDirectoryOnly
            )
          );
        }
      }

      foreach (var mod in modAssemblies)
      {
          Assembly assembly = Assembly.LoadFrom(mod);
          foreach (var type in assembly.GetTypes())
          {
            if (typeof(Mod).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
            {
              Mod instance = (Mod)Activator.CreateInstance(type);
              instance.OnLoad();
              activeMods.Add(instance);
            }
          }
      }
    }
  }
}