using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

class Level{
   private List<GameObject> _objects = new List<GameObject>();
   private List<GameObject> _pendingAdd = new List<GameObject>();
   private List<GameObject> _pendingRemove = new List<GameObject>();
   public void Update(float dt){
      foreach(var obj in _objects)
         obj.Update(dt);

      _objects.AddRange(_pendingAdd);
      _pendingAdd.Clear();

      foreach(var obj in _pendingRemove)
         _objects.Remove(obj);
      _pendingRemove.Clear();
   }
   public void Render(RenderTarget rt)
   {
      foreach (var obj in _objects)
      {
         RenderStates states = RenderStates.Default;
         states.Transform = obj.Transform;
         foreach (var shape in obj.Shapes)
         {
            rt.Draw(shape, states);
         }
      }
   }
   public void SpawnObject(GameObject obj, Vector2f position){
      obj.OwningLevel = this;
      obj.Position = position;
      _pendingAdd.Add(obj);
   }
   public void SpawnObject(GameObject obj){
      SpawnObject(obj, new Vector2f(0, 0));
   }

   public void DestroyObject(GameObject obj){
      _pendingRemove.Add(obj);
   }
}