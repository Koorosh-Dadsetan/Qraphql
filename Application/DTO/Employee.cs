using GraphQL.Types;

namespace Application.DTO
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string Mobile { get; set; }
    }

    public class EmployeeDetailsType : ObjectGraphType<EmployeeDetails>
    {
        public EmployeeDetailsType()
        {
            Field(x => x.Id);
            Field(x => x.FullName);
            Field(x => x.Age, nullable: true);
            Field(x => x.Mobile);
        }
    }
}
