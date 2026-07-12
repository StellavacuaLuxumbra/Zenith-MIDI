# Camera Script Feature for MIDITrail+ Renderer

## Overview

The MIDITrail+ renderer now supports **TypeScript-style camera control scripts**. You can load custom C# scripts at runtime to control the camera position, rotation, FOV, and other parameters.

## How to Use

1. **Open the MIDITrail+ renderer settings** in Zenith MIDI
2. **Click "Load Camera Script (.cs)"** button at the bottom right of the settings panel
3. **Select a .cs script file** from your computer
4. The script will be compiled and executed immediately, updating all camera settings

## Script Format

Your script must contain a public class named `CameraScript` with a public method named `UpdateCamera` that takes a `Settings` object as parameter.

### Basic Template

```csharp
using System;
using MIDITrailRender;

public class CameraScript
{
    public void UpdateCamera(Settings settings)
    {
        // Set your camera parameters here
        settings.viewOffset = 0.4;      // X position
        settings.viewHeight = 0.5;       // Y position
        settings.viewPan = 0.0;          // Z position
        settings.camAng = 0.56;          // Vertical rotation (radians)
        settings.camRot = 0.0;           // Horizontal rotation (radians)
        settings.camSpin = 0.0;          // Roll rotation (radians)
        settings.FOV = Math.PI / 3;      // Field of view (radians)
        settings.viewdist = 14.0;        // View distance forward
        settings.viewback = 0.2;         // View distance backward
    }
}
```

## Camera Parameters Reference

### Position (XYZ)

| Parameter | Description | Range | Default |
|-----------|-------------|-------|---------|
| `viewOffset` | X-axis offset (left/right pan) | -20 to 15 | 0.4 |
| `viewHeight` | Y-axis offset (up/down) | 0 to 10 | 0.5 |
| `viewPan` | Z-axis offset (forward/backward) | -20 to 20 | 0.0 |

### Rotation

| Parameter | Description | Range | Default |
|-----------|-------------|-------|---------|
| `camAng` | Vertical rotation (tilt up/down) | -π/2 to π/2 | 0.56 rad (~32°) |
| `camRot` | Horizontal rotation (turn left/right) | -π to π | 0.0 |
| `camSpin` | Roll rotation (Dutch angle) | -π to π | 0.0 |

**Note:** All rotation values are in **radians**. To convert from degrees: `radians = degrees * Math.PI / 180`

### Field of View

| Parameter | Description | Range | Default |
|-----------|-------------|-------|---------|
| `FOV` | Field of view angle | 5° to 150° | 60° (π/3 rad) |

Lower values = zoomed in, higher values = wide angle

### Render Distance

| Parameter | Description | Range | Default |
|-----------|-------------|-------|---------|
| `viewdist` | How far the camera can see forward | 0 to 200 | 14.0 |
| `viewback` | How far behind the camera can see | 0 to 200 | 0.2 |

## Example Scripts

See `CameraScriptExample.cs` for complete examples including:
- Low angle dramatic shots
- Top-down views
- Dynamic swooping cameras
- Extreme wide angles
- Dutch angle (tilted) shots

## Tips

1. **Use radians for rotations**: Remember that C# trigonometric functions use radians, not degrees
2. **Start with presets**: Try the built-in camera presets first, then fine-tune with scripts
3. **Save your scripts**: Keep your favorite camera setups as .cs files for reuse
4. **Combine with profiles**: Use the profile system to save complete settings including script-applied values

## Troubleshooting

- **"Script must contain a class named 'CameraScript'"**: Make sure your class is named exactly `CameraScript` (case-sensitive)
- **"Script must contain a method named 'UpdateCamera'"**: Make sure you have a public method `UpdateCamera(Settings settings)`
- **Compilation errors**: Check the error message for line numbers and fix any syntax errors
- **Camera doesn't move**: Make sure you're actually setting the properties (use `=` not `==`)
