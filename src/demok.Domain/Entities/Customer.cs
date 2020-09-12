using FluentValidation;

namespace demok.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, decimal salary, string email)
        {
            Name = name;
            Salary = salary;
            Email = email;
        }

        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public string Email { get; private set; }

        public void UpdateCustomer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public bool UpdateSalary(decimal salary)
        {
            Salary = salary;
            return true;
        }
    }

    public class CustomerValidation : AbstractValidator<Customer>
    {
        public static string NameErroMsg => "Nome inválido.";
        public static string SalaryErroMsg => "Salario inválido.";
        public static string EmailErroMsg => "E-mail inválido";

        public CustomerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(NameErroMsg);

            RuleFor(c => c.Salary)
                .NotEmpty()
            .WithMessage(SalaryErroMsg);

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage(EmailErroMsg);
        }
    }
}