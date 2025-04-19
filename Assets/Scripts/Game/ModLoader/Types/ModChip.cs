using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DLS.Description;
using DLS.Description.Types;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.ModLoader.Types
{
  public class ModChip : ISimChip
  {
    public string ChipName => GetType().Name;
    [CanBeNull] private ChipDescription _chip;
    public ChipDescription Chip
    {
      get
      {
        _chip ??= new ChipDescription()
        {
          Name = ChipName,
          NameLocation = NameDisplayLocation.Centre,
          Colour = Color.red,
          Size = new Vector2(2, 2),
          InputPins = Array.Empty<PinDescription>(),
          OutputPins = Array.Empty<PinDescription>(),
          SubChips = Array.Empty<SubChipDescription>(),
          Displays = Array.Empty<DisplayDescription>(),
          Wires = Array.Empty<WireDescription>(),
          ChipType = ChipType.Modded
        };
        if (_chip.Name == null) _chip.Name = ChipName;
        return _chip;
      }
      protected set => _chip = value;
    }

    public virtual void SetDefaults()
    {
      
    }

    protected PinDescription CreatePinDescription(string name, int pinId, PinBitCount bitCount, PinColour colour = PinColour.Red, PinValueDisplayMode visibility = PinValueDisplayMode.Off)
    {
      return new PinDescription(name, pinId, Vector2.zero, bitCount, colour, visibility);
    }

    protected void SetNameLocation(NameDisplayLocation location)
    {
      _chip.NameLocation = location;
    }

    protected void SetColor(Color colour)
    {
      _chip.Colour = colour;
    }

    public virtual void Simulate(UInt64[] InternalData, in Pin[] Input, ref Pin[] Output)
    {
      
    }
  }
}