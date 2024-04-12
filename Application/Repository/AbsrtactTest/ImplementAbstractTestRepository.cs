namespace Application.Repository.AbsrtactTest
{
    public class ImplementAbstractTestRepository : AbstractTestRepository
    {
        public override string AbstractMethod() => "This is override AbstractMethod";

        public override string VirtualMethod() => base.VirtualMethod();
    }
}
