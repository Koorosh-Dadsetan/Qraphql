using Microsoft.AspNetCore.Mvc;

namespace OneApiForAllEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTwoController : ControllerBase
    {
        [HttpGet("CheckRefKeyboard")]
        public string CheckRefKeyboard()
        {
            string fds = "2";

            Change(ref fds);

            NotChange(fds);

            return fds;
        }

        [NonAction]
        public void Change(ref string myParam) => myParam = "3";

        [NonAction]
        public void NotChange(string myParam) => myParam = "4";

        [HttpGet("Class")]
        public myClass myClass()
        {
            return new myClass { Name = "Koorosh", Age = 25 };
        }

        [HttpGet("Struct")]
        public myStruct myStruct()
        {
            return new myStruct { Name = "Koorosh", Age = 25 };
        }

        [HttpGet("Record")]
        public myRecord myRecord()
        {
            return new myRecord("Koorosh", 25);
        }
    }

    public class myClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public struct myStruct
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public record myRecord(string Name, int Age);
}
