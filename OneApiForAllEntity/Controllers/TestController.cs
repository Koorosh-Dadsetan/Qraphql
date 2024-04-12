using Application.Repository.AbsrtactTest;
using Microsoft.AspNetCore.Mvc;

namespace OneApiForAllEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AbstractTestRepository _MyAbstractClass;
        public TestController(AbstractTestRepository MyAbstractClass2) => _MyAbstractClass = MyAbstractClass2;

        [HttpGet]
        public ActionResult<string> Index() => $"{_MyAbstractClass.AbstractMethod()} | {_MyAbstractClass.VirtualMethod()}";
    }
}
