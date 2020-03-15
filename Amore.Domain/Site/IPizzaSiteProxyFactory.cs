namespace amore.domain.Site
{
    public interface IPizzaSiteProxyFactory
    {
        IPizzaSiteProxy Create(PizzaPlace pizzaPlace);
    }

    public enum PizzaPlace
    {
        AMORE
    }
}