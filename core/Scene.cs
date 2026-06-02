using System.Collections.Generic;
using System.Net;

namespace geng;

public class Scene
{
    public void Initialize()
    {
        
    }
    public void Update()
    {
        particleHandler.Update();
        
    }
    public void Draw()
    {
        particleHandler.Draw();
        _map.Draw();
        
    }
    private ParticleHandler particleHandler;
    private List<IParticle> _particles;
    private List<IEntity> _entities;
    private Map _map = Engine.Get<Map>();
}