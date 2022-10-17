using Godot;
using System;

public struct CloudSpawns {
    public string cloudResourcePath;
    public PackedScene CloudResource;
    public CloudMovement cloud;
    public VisibilityNotifier2D cloudVisibility;
}