﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public ProjectManagementHelper Projects { get; set; }
        public LoginHelper Auth { get; set; }
        public NavigationHelper Navigator { get; set; }
       // public JamesHelper James { get; set; }
        //public MailHelper Mail { get; set; }
       //public AdminHelper Admin { get; set; }
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            
            baseURL = "http://localhost/mantisbt-2.24.0/";

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Projects = new ProjectManagementHelper(this);
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, baseURL);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}