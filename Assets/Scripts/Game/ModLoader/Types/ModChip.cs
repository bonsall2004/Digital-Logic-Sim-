using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DLS.Description;
using DLS.Description.Types;
using UnityEngine;

namespace Game.ModLoader.Types
{
  public class ModChip
  {
    public string ChipName => GetType().Name;
    private ChipDescription _chip;
    private List<PinDescription> InputPins = new List<PinDescription>();
    private List<PinDescription> OutputPins = new List<PinDescription>();
    private int previousPinId = 0;
    public ChipDescription Chip
    {
      get
      {
        _chip.InputPins = InputPins.ToArray();
        _chip.OutputPins = OutputPins.ToArray();
        return _chip;
      }
      protected set => _chip = value;
    }

    protected int AddInput(string name, PinBitCount bitCount, PinColour colour = PinColour.Red, PinValueDisplayMode visibility = PinValueDisplayMode.Off)
    {
      InputPins.Add(new PinDescription(name, previousPinId, Vector2.zero, bitCount, colour, visibility));
      return previousPinId++;
    }

    protected int AddOutput(string name, PinBitCount bitCount, PinColour colour = PinColour.Red, PinValueDisplayMode visibility = PinValueDisplayMode.Off)
    {
      InputPins.Add(new PinDescription(name, previousPinId, Vector2.zero, bitCount, colour, visibility));
      return previousPinId++;
    }

    protected void SetNameLocation(NameDisplayLocation location)
    {
      _chip.NameLocation = location;
    }

    protected void SetColor(Color colour)
    {
      _chip.Colour = colour;
    }
    
    public virtual void Simulate(ref UInt64[] state, ref UInt64[] inputs, ref UInt64[] outputs)
    {
      
    }
  }
}