namespace Salacia.Common.Domain
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
    }
}