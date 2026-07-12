// Camera Control Script Example for MIDITrail+ Renderer
// This script allows you to control the camera position, rotation, and FOV
// using TypeScript-like syntax (compiled as C# at runtime)

using System;
using MIDITrailRender;

public class CameraScript
{
    // This method is called when the script is loaded
    // It receives the Settings object which controls all camera parameters
    public void UpdateCamera(Settings settings)
    {
        // ============================================
        // CAMERA POSITION (XYZ)
        // ============================================
        
        // viewOffset: X-axis offset (left/right pan)
        // Positive values move camera right, negative moves left
        settings.viewOffset = 0.4;
        
        // viewHeight: Y-axis offset (up/down)
        // Higher values move camera up, lower moves down
        settings.viewHeight = 0.5;
        
        // viewPan: Z-axis offset (forward/backward)
        // Positive values move camera forward, negative moves back
        settings.viewPan = 0.0;
        
        // ============================================
        // CAMERA ROTATION
        // ============================================
        
        // camAng: Vertical rotation (tilt up/down)
        // Value is in radians. 0.56 rad ≈ 32 degrees
        // Positive tilts down, negative tilts up
        settings.camAng = 0.56;
        
        // camRot: Horizontal rotation (turn left/right)
        // Value is in radians. 0 = straight ahead
        // Positive turns right, negative turns left
        settings.camRot = 0.0;
        
        // camSpin: Roll rotation (spin clockwise/counter-clockwise)
        // Value is in radians. 0 = no roll
        // Positive spins clockwise, negative counter-clockwise
        settings.camSpin = 0.0;
        
        // ============================================
        // FIELD OF VIEW (FOV)
        // ============================================
        
        // FOV: Field of view angle in radians
        // Math.PI / 3 ≈ 60 degrees (standard FOV)
        // Lower values = zoomed in, higher values = wide angle
        settings.FOV = Math.PI / 3;
        
        // ============================================
        // RENDER DISTANCE
        // ============================================
        
        // viewdist: How far the camera can see forward
        // Higher values show more of the track ahead
        settings.viewdist = 14.0;
        
        // viewback: How far behind the camera can see
        // Usually kept small
        settings.viewback = 0.2;
    }
}

// ============================================
// EXAMPLE SCRIPTS
// ============================================

/*
// Example 1: Dramatic low angle shot
public class CameraScript_LowAngle
{
    public void UpdateCamera(Settings settings)
    {
        settings.viewOffset = 0.0;
        settings.viewHeight = 0.2;      // Low camera position
        settings.viewPan = 0.5;         // Pushed forward
        settings.camAng = 0.8;          // Looking up more
        settings.camRot = 0.0;
        settings.camSpin = 0.0;
        settings.FOV = Math.PI / 2.5;   // Wider FOV for drama
        settings.viewdist = 20.0;
    }
}

// Example 2: Top-down view
public class CameraScript_TopDown
{
    public void UpdateCamera(Settings settings)
    {
        settings.viewOffset = -3.77;
        settings.viewHeight = 10.0;     // High above
        settings.viewPan = -1.53;
        settings.camAng = Math.PI / 2;  // Looking straight down (90 degrees)
        settings.camRot = -Math.PI / 2; // Rotate to align
        settings.camSpin = 0.0;
        settings.FOV = 26.0 * Math.PI / 180;
        settings.viewdist = 8.0;
    }
}

// Example 3: Dynamic swooping camera
public class CameraScript_Swoop
{
    public void UpdateCamera(Settings settings)
    {
        settings.viewOffset = 1.07;
        settings.viewHeight = 0.67;
        settings.viewPan = -0.32;
        settings.camAng = 33.24 * Math.PI / 180;
        settings.camRot = -13.84 * Math.PI / 180;
        settings.camSpin = 0.0;
        settings.FOV = 60.0 * Math.PI / 180;
        settings.viewdist = 14.0;
    }
}

// Example 4: Extreme wide angle
public class CameraScript_WideAngle
{
    public void UpdateCamera(Settings settings)
    {
        settings.viewOffset = 0.0;
        settings.viewHeight = 1.0;
        settings.viewPan = 0.0;
        settings.camAng = 0.5;
        settings.camRot = 0.0;
        settings.camSpin = 0.0;
        settings.FOV = Math.PI / 2;     // 90 degrees - very wide!
        settings.viewdist = 25.0;       // Can see very far
    }
}

// Example 5: Dutch angle (tilted for dramatic effect)
public class CameraScript_DutchAngle
{
    public void UpdateCamera(Settings settings)
    {
        settings.viewOffset = 0.0;
        settings.viewHeight = 0.5;
        settings.viewPan = 0.0;
        settings.camAng = 0.6;
        settings.camRot = 0.0;
        settings.camSpin = Math.PI / 12; // 15 degree tilt
        settings.FOV = Math.PI / 3;
        settings.viewdist = 14.0;
    }
}
*/
