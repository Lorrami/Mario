using SFML.Graphics;
using SFML.System;


abstract class GameObject: RectangleShape{
    public Level? OwningLevel{private get; set;}

    public abstract void Update(float dt);

    public void Spawn(GameObject obj){
        if(OwningLevel is null)
            throw new Exception("Null owning level");
        
        OwningLevel.SpawnObject(obj);
    }
}