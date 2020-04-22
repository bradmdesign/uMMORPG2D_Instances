uMMORPG 2D Instances


# uMMORPG2D_Instances
This is an asset that allows players to create instanced zones in their 2d MMORPG, all utilizing only one scene. This can be used in just about any networked game in the 2d world, as well as many in the 3d world with some modification.

NOTE: If you use navmeshes/a tilemap like I do, you'll need to use vis2k's nav2d: https://noobtuts.com/unity/navigation2d


For a tutorial, please go here: https://streamable.com/e/8ujim4


Steps:

1. Extract all files to your Unity Project.
2. Turn whatever tilemap you'd like to use into a prefab. 
3. Add the tag "Instance" and tag your newly created Prefab with it.
4. Add the "Zone Index" script to your instance.
5. Create an empty object in your scene to be a parent of your instance. 
6. Add the "Instance Zone" script to it and nothing else. In our example, our parent object is "Intro Instance" (ref: https://i.imgur.com/rEs7ms1.png)
7. Set the Distance Between Zones so that you can't see it from game or from minimap. I chose 100. This adds the instance at the same location, but +100 on the X axis.
8. Drag the prefab of your instance underneath your newly created parent object.
9. Add the "Zone Index" script to your instance.

Now, if you were to go in game and press the "go" boolean, it would show you how it looks when a new instance is created.

Let's precook a few Nav meshes.

1. On your parent object, you'll see the field "Instances to Create". Set that number to 20.
2. Press "Play", and then click "Prebake Nav Mesh".
3. Once they have been spawned, go to your Navigation2D window and click "Bake"
4. *Optional* If you have several instances (tagged with Instance), you can spawn all of them at once by dragging the InstanceSpawner into the scene and clicking "Create Instances". This will go through all of your prefabs tagged "Instance" and start the Prebake Nav Mesh button on them. 


NOTE: This isn't a perfect solution for 2d navmesh users. The reason why we pre-bake nav meshes is so that when one spawns in that area, players can walk. If anyone wants to expand on this or figure out a way to pre-bake 2d navmeshes, please contact me/branch!
</strong>NOTE 2: Instancing like this reserves this X axis - so be sure to build your additional rooms on the Y axis.
