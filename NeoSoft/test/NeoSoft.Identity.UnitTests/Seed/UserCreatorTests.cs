﻿using NeoSoft.Identity.Seed;
using NeoSoft.Identity.UnitTests.Fakes;
using NeoSoft.Identity.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace NeoSoft.Identity.UnitTests.Seed
{
    public class UserCreatorTests
    {
        private readonly static Mock<FakeUserManager> _mockUserManager;
        static UserCreatorTests()
        {
            _mockUserManager = UserManagerMocks.GetUserManager();
        }

        [Fact]
        public async static Task Create_First_User()
        {
            var oldCount = _mockUserManager.Object.Users.ToList().Count();

            await Should.NotThrowAsync(() => UserCreator.SeedAsync(_mockUserManager.Object));

            var newCount = _mockUserManager.Object.Users.ToList().Count();
            newCount.ShouldBe(oldCount + 1);
        }
    }
}
