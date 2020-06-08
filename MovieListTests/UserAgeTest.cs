using MovieList.Models;
using System;
using Xunit;
using Xunit.Sdk;
using MovieList.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace MovieListTests
{
    public class UserAgeTest
    {
        [Fact]
        public void AgeThisYearTest()
        {
            //Arrange
            UserAgeModel model = new UserAgeModel();
            model.Name = "Hillary";
            model.BirthYear = 1986;
            int Expected = 34;
            int Actual = 0;

            //Act
            Actual = model.AgeThisYear();

            //Assert
            Assert.Equal(Expected, Actual);
        }

        [Fact]
        public void NameRequiredTest()
        {
            //Arrange
            UserAgeModel model = new UserAgeModel();
            model.Name = null;
            model.BirthYear = 1986;
            //string Expected = "Please enter your name.";

            //Act - Nothing to really put here

            //Assert
            Assert.Contains(ValidateModel(model),
                actual => actual.MemberNames.Contains("Name") &&
            actual.ErrorMessage.Contains("Please enter your name"));
        }

        [Fact]
        public void BirthYearRequiredTest()
        {
            //Arrange
            UserAgeModel model = new UserAgeModel();
            model.Name = "Tester";
            model.BirthYear = null;
            //string Expected = "Please enter your birth year.";

            //Act - Nothing to really put here

            //Assert
            Assert.Contains(ValidateModel(model),
                actual => actual.MemberNames.Contains("BirthYear") &&
            actual.ErrorMessage.Contains("Please enter your birth year"));
        }

        [Fact]
        public void BirthYearMustBeValidTest()
        {
            //Arrange
            UserAgeModel model = new UserAgeModel();
            model.Name = "Tester";
            model.BirthYear = 1700;
            //string Expected = "Please enter your birth year.";

            //Act - Nothing to really put here

            //Assert
            Assert.Contains(ValidateModel(model),
                actual => actual.MemberNames.Contains("BirthYear") &&
            actual.ErrorMessage.Contains("Birth year must be year 1900 - 2020."));
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
