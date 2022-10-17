using Godot;
using System;

public class CloudSpawner : Position2D
{
    private CloudSpawns[] cloudArray = new CloudSpawns[6];

    public override void _Ready()
    {
        for (int i = 0; i < cloudArray.Length; i++) {
            instantiateTheCloud(i + 1);
        }
    }

    public override void _Process(float delta)
    {
        // Cloud One check
        if (!IsInstanceValid(cloudArray[0].cloud)) {
            cloudArray[0].cloud = cloudArray[0].CloudResource.Instance<CloudMovement>();
            cloudArray[0].cloud.GlobalPosition = new Vector2(170, RandomVerticalNumGen());
            CallDeferred("add_child", cloudArray[0].cloud);
            cloudArray[0].cloudVisibility = cloudArray[0].cloud.GetNode<VisibilityNotifier2D>("./VisibilityNotifier2D");
        }

        if (cloudArray[0].cloudVisibility.IsOnScreen() && 
        !cloudArray[0].cloudVisibility.IsConnected("screen_exited", this, nameof(this.DestroyCloud))) {
            cloudArray[0].cloudVisibility.Connect("screen_exited", this, nameof(this.DestroyCloud), new Godot.Collections.Array{0});
        }

        // Cloud Two check
        if (!IsInstanceValid(cloudArray[1].cloud)) {
            cloudArray[1].cloud = cloudArray[1].CloudResource.Instance<CloudMovement>();
            cloudArray[1].cloud.GlobalPosition = new Vector2(170, RandomVerticalNumGen());
            CallDeferred("add_child", cloudArray[1].cloud);
            cloudArray[1].cloudVisibility = cloudArray[1].cloud.GetNode<VisibilityNotifier2D>("./VisibilityNotifier2D");
        }

        if (cloudArray[1].cloudVisibility.IsOnScreen() && 
        !cloudArray[1].cloudVisibility.IsConnected("screen_exited", this, nameof(this.DestroyCloud))) {
            cloudArray[1].cloudVisibility.Connect("screen_exited", this, nameof(this.DestroyCloud), new Godot.Collections.Array{1});
        }

        // Cloud Three check
        if (!IsInstanceValid(cloudArray[2].cloud)) {
            cloudArray[2].cloud = cloudArray[2].CloudResource.Instance<CloudMovement>();
            cloudArray[2].cloud.GlobalPosition = new Vector2(170, RandomVerticalNumGen());
            CallDeferred("add_child", cloudArray[2].cloud);
            cloudArray[2].cloudVisibility = cloudArray[2].cloud.GetNode<VisibilityNotifier2D>("./VisibilityNotifier2D");
        }

        if (cloudArray[2].cloudVisibility.IsOnScreen() && 
        !cloudArray[2].cloudVisibility.IsConnected("screen_exited", this, nameof(this.DestroyCloud))) {
            cloudArray[2].cloudVisibility.Connect("screen_exited", this, nameof(this.DestroyCloud), new Godot.Collections.Array{2});
        }

        // Cloud Four check
        if (!IsInstanceValid(cloudArray[3].cloud)) {
            cloudArray[3].cloud = cloudArray[3].CloudResource.Instance<CloudMovement>();
            cloudArray[3].cloud.GlobalPosition = new Vector2(170, RandomVerticalNumGen());
            CallDeferred("add_child", cloudArray[3].cloud);
            cloudArray[3].cloudVisibility = cloudArray[3].cloud.GetNode<VisibilityNotifier2D>("./VisibilityNotifier2D");
        }

        if (cloudArray[3].cloudVisibility.IsOnScreen() && 
        !cloudArray[3].cloudVisibility.IsConnected("screen_exited", this, nameof(this.DestroyCloud))) {
            cloudArray[3].cloudVisibility.Connect("screen_exited", this, nameof(this.DestroyCloud), new Godot.Collections.Array{3});
        }

        // Cloud Five check
        if (!IsInstanceValid(cloudArray[4].cloud)) {
            cloudArray[4].cloud = cloudArray[4].CloudResource.Instance<CloudMovement>();
            cloudArray[4].cloud.GlobalPosition = new Vector2(170, RandomVerticalNumGen());
            CallDeferred("add_child", cloudArray[4].cloud);
            cloudArray[4].cloudVisibility = cloudArray[4].cloud.GetNode<VisibilityNotifier2D>("./VisibilityNotifier2D");
        }

        if (cloudArray[4].cloudVisibility.IsOnScreen() && 
        !cloudArray[4].cloudVisibility.IsConnected("screen_exited", this, nameof(this.DestroyCloud))) {
            cloudArray[4].cloudVisibility.Connect("screen_exited", this, nameof(this.DestroyCloud), new Godot.Collections.Array{4});
        }

        // Cloud Six check
        if (!IsInstanceValid(cloudArray[5].cloud)) {
            cloudArray[5].cloud = cloudArray[5].CloudResource.Instance<CloudMovement>();
            cloudArray[5].cloud.GlobalPosition = new Vector2(170, RandomVerticalNumGen());
            CallDeferred("add_child", cloudArray[5].cloud);
            cloudArray[5].cloudVisibility = cloudArray[5].cloud.GetNode<VisibilityNotifier2D>("./VisibilityNotifier2D");
        }

        if (cloudArray[5].cloudVisibility.IsOnScreen() && 
        !cloudArray[5].cloudVisibility.IsConnected("screen_exited", this, nameof(this.DestroyCloud))) {
            cloudArray[5].cloudVisibility.Connect("screen_exited", this, nameof(this.DestroyCloud), new Godot.Collections.Array{5});
        }
    }

    private void DestroyCloud(int cloudNum) {
        cloudArray[cloudNum].cloud.QueueFree();
    }

    private float RandomVerticalNumGen() {
        return (float)GD.RandRange(16, 8);
    }

    private void instantiateTheCloud(int iteration) {

        switch(iteration) {
            case 1:
                cloudArray[iteration - 1].cloudResourcePath = "res://Scenes/Clouds/Cloud_Scene_001.tscn";
                cloudArray[iteration - 1].CloudResource = GD.Load<PackedScene>(cloudArray[iteration - 1].cloudResourcePath);
                break;

            case 2:
                cloudArray[iteration - 1].cloudResourcePath = "res://Scenes/Clouds/Cloud_Scene_002.tscn";
                cloudArray[iteration - 1].CloudResource = GD.Load<PackedScene>(cloudArray[iteration - 1].cloudResourcePath);
                break;

            case 3:
                cloudArray[iteration - 1].cloudResourcePath = "res://Scenes/Clouds/Cloud_Scene_003.tscn";
                cloudArray[iteration - 1].CloudResource = GD.Load<PackedScene>(cloudArray[iteration - 1].cloudResourcePath);
                break;

            case 4:
                cloudArray[iteration - 1].cloudResourcePath = "res://Scenes/Clouds/Cloud_Scene_004.tscn";
                cloudArray[iteration - 1].CloudResource = GD.Load<PackedScene>(cloudArray[iteration - 1].cloudResourcePath);
                break;

            case 5:
                cloudArray[iteration - 1].cloudResourcePath = "res://Scenes/Clouds/Cloud_Scene_005.tscn";
                cloudArray[iteration - 1].CloudResource = GD.Load<PackedScene>(cloudArray[iteration - 1].cloudResourcePath);
                break;

            case 6:
                cloudArray[iteration - 1].cloudResourcePath = "res://Scenes/Clouds/Cloud_Scene_006.tscn";
                cloudArray[iteration - 1].CloudResource = GD.Load<PackedScene>(cloudArray[iteration - 1].cloudResourcePath);
                break;
        }
    }
}
