﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        public AccountData account = new AccountData()
        {
            Name = "administrator",
            Password = "admin"
        };

        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(account);
        }
    }
}