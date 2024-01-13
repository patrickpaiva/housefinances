﻿using AutoMapper;
using HouseFinances.Data;
using HouseFinances.DTO;
using HouseFinances.Entities;
using HouseFinances.Repositories;
using HouseFinances.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseFinances.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly DataContext _context;

        public LookupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("expense-types")]
        public ActionResult<IEnumerable<ExpenseType>> GetExpenseTypes()
        {
            var expenseTypes = _context.ExpenseTypes.ToList();
            return Ok(expenseTypes);
        }

        [HttpGet("rubric-items")]
        public ActionResult<IEnumerable<RubricItem>> GetRubricItems()
        {
            var rubricItems = _context.RubricItems.ToList();
            return Ok(rubricItems);
        }

        [HttpGet("persons")]
        public ActionResult<IEnumerable<RubricItem>> GetPersons()
        {
            var persons = _context.Persons.ToList();
            return Ok(persons);
        }

        [HttpGet("payment-methods")]
        public ActionResult<IEnumerable<RubricItem>> GetPaymentMethods()
        {
            var paymentMethods = _context.PaymentMethods.ToList();
            return Ok(paymentMethods);
        }

        [HttpGet("payment-methods/{carrierId}")]
        public ActionResult<IEnumerable<PaymentMethod>> GetPaymentMethods(int carrierId)
        {
            var paymentMethods = _context.Carriers
                .Where(c => c.CarrierID == carrierId)
                .SelectMany(c => c.PaymentMethods)
                .ToList();

            return Ok(paymentMethods);
        }

        [HttpGet("carriers")]
        public ActionResult<IEnumerable<RubricItem>> GetCarriers()
        {
            var carriers = _context.Carriers
                .Include(c => c.CarrierType)
                .Include(c => c.PaymentMethods)
                .Include(c => c.Person)
                .ToList();
            return Ok(carriers);
        }

    }

}
