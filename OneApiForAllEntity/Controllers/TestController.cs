using Microsoft.AspNetCore.Mvc;

namespace OneApiForAllEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyAbstractClass _MyAbstractClass;
        public TestController(MyAbstractClass MyAbstractClass2) => _MyAbstractClass = MyAbstractClass2;

        [HttpGet]
        public ActionResult<string> Index() => $"{_MyAbstractClass.AbstractMethod()} | {_MyAbstractClass.VirtualMethod()}";
    }

    public abstract class MyAbstractClass
    {
        public abstract string AbstractMethod();

        public virtual string VirtualMethod() => "This is VirtualMethod";
    }

    public class ImplementClass : MyAbstractClass
    {
        public override string AbstractMethod() => "This is override AbstractMethod";

        public override string VirtualMethod() => base.VirtualMethod();
    }
}
