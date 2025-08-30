
namespace Company.DAL.Entity
{
    public class Employee
    {
       public int Id { get;  set; }
        public string?  Name { get; set; }
        public int Age {  get; set; }
        
        public decimal Salary {  get; set; }
        public Boolean IsDeleted {  get; set; }
        public DateTime DeletedON {   get; set; }
        public string? UpdatedBy {   get; set; }
        public DateTime UpdatedON {   get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string? ImageURL { get; set; }
        

        public bool Update(string updatedby,string Name,int Age)
        {
            if (string.IsNullOrEmpty(updatedby))
                return false;
            this.UpdatedBy = updatedby;
            this.Name = Name;
            this.Age = Age;
            return true;
        }
        public bool togglestatus(string Deletedby)
        {
            if (string.IsNullOrEmpty(Deletedby))
                return false;
            IsDeleted = !IsDeleted;
            DeletedON= DateTime.Now;
            return true;

        }
    }
}
