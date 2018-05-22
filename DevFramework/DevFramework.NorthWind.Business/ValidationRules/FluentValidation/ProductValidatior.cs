﻿using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior :AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).Length(2,20);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p=>p.CategoryId==1);
            //RuleFor(p => p.ProductName).Must(StartWithA);

            //bool StartWithA(string arg)
            //{
            //    return arg.StartsWith("A");
            //} gibiiii
        }
    }
}