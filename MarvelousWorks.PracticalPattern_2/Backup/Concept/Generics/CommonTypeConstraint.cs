namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    public interface IOrganization { }

    public abstract class UserBase<TKey, TOrganization>
        where TOrganization : class, IOrganization, new()
    {
        public abstract TOrganization Organization { get;}  // method
        public abstract void Promotion(TOrganization newOrganization); // property
        delegate TOrganization OrganizationChangedHandler(); // delegate
    }
}
