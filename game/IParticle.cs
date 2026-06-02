namespace geng;

public interface IParticle :  IEntity
{
    /// <summary>
    /// For particles to be GCed, this should indicate when time to live has ran out.
    /// </summary>
    /// <returns></returns>
    bool isAlive();
}
