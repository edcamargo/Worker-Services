using FluentValidation;
using FluentValidation.Results;
using System;

namespace demok.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, double salary, string email)
        {
            Name = name;
            Salary = salary;
            Email = email;
        }

        public string Name { get; private set; }
        public double Salary { get; private set; }
        public string Email { get; private set; }

        public void UpdateCustomer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void UpdateSalary(double percentual)
        {
            var _newSalary = Salary * percentual;
            Salary = Math.Round(_newSalary, 2, MidpointRounding.ToEven);
        }
        
        public ValidationResult EhValido()
        {
            return new CustomerValidation().Validate(this);
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
                .GreaterThan(0)
            .WithMessage(SalaryErroMsg);

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage(EmailErroMsg);
        }
    }
}