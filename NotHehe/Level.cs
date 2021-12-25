using SFML.Graphics;
using System.Collections.Generic;
class Level{
   private List<GameObject> _objects = new List<GameObject>();

   public void Update(float dt){
      foreach(var obj in _objects)
         obj.Update(dt);
   }

   public void Render(RenderWindow window){
      foreach(var obj in _objects)
         obj.Render(window);
   }

   void SpawnObject(GameObject obj){
      obj.OwningLevel = this;
      _objects.Add(obj);
   }
}