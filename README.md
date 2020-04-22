# uMMORPG2D_Instances
This is an asset that allows players to create instanced zones in their 2d MMORPG. This can be used in just about any networked game in the 2d world, as well as many in the 3d world with some modification.

NOTE: If you use navmeshes/a tilemap like I do, you'll need to use <a href="https://noobtuts.com/unity/navigation2d">vis2k's nav2d from noobtuts.com</a> or the Unity Asset store.


For a tutorial, please see below.

<div style="width:100%;height:0px;position:relative;padding-bottom:56.250%;"><media src="https://streamable.com/e/8ujim4" frameborder="0" width="100%" height="100%" allowfullscreen style="width:100%;height:100%;position:absolute;left:0px;top:0px;overflow:hidden;"></iframe></div>

 <video controls>
  <source src="https://streamable.com/e/8ujim4" type="video/mp4">
Your browser does not support the video tag.
</video> 

Steps:

1. Extract all files to your Unity Project.
2. Turn whatever tilemap you'd like to use into a prefab. 
3. Add the tag "Instance" and tag your newly created Prefab with it.
4. Add the "Zone Index" script to your instance.
4. Create an empty object in your scene to be a parent of your instance. 
5. Add the "Instance Zone" script to it and nothing else. In our example, our parent object is "Intro Instance"
<img src="https://i.imgur.com/rEs7ms1.png">
6. Set the Distance Between Zones so that you can't see it from game or from minimap. I chose 100. This adds the instance at the same location, but +100 on the X axis.
5. Drag the prefab of your instance underneath your newly created parent object.
6. Add the "Zone Index" script to your instance.

Now, if you were to go in game and press the "go" boolean, it would show you how it looks when a new instance is created.

Let's precook a few nav meshes.

1. On your parent object, you'll see the field "Instances to Create". Set that number to 20.
2. Press "Play", and then click "Prebake Nav Mesh".
3. Once they have been spawned, go to your Navigation2D window and click "Bake"
4. ~Optional~ If you have several instances (tagged with Instance), you can spawn all of them at once by dragging the InstanceSpawner into the scene and clicking "Create Instances". This will go through all of your prefabs tagged "Instance" and start the Prebake Nav Mesh button on them. 
