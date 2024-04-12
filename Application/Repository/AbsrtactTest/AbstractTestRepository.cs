namespace Application.Repository.AbsrtactTest
{
    public abstract class AbstractTestRepository
    {
        public abstract string AbstractMethod();

        public virtual string VirtualMethod() => "This is VirtualMethod";
    }
}
