﻿using System;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace Gauge.Example.Implementation
{
    public class DriverFactory
    {
        public static IWebDriver Driver { get; private set; }

        [BeforeSuite]
        public void Setup() {
            bool useIe;
            bool.TryParse(Environment.GetEnvironmentVariable("USE_IE"), out useIe);
            if (useIe)
            {
                Driver=new InternetExplorerDriver();
            }
            else
            {
                Driver =new ChromeDriver();
            }
        }

        [AfterSuite]
        public void TearDown() {
            Driver.Close();
        }
    }
}
