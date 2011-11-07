﻿using System;
using System.Linq;
using System.Net;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_build_status_info
    {
        private TeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void it_throws_exception_when_no_url_passed()
        {
            var client = new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_throws_exception_when_host_does_not_exist()
        {
            var client = new TeamCityClient("test:81");
            client.Connect("admin", "qwerty");

            string buildConfigName = "Local Debug Build";
            var builds = client.SuccessfulBuildsByBuildConfigName(buildConfigName);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("localhost:81");

            string buildConfigName = "Local Debug Build";
            var builds = client.SuccessfulBuildsByBuildConfigName(buildConfigName);

            //Assert: Exception
        }

        [Test]
        public void it_returns_last_successful_build_by_build_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var build = _client.LastSuccessfulBuildByBuildConfigName(buildConfigName);

            Assert.That(build != null, "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_successful_builds_by_build_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var buildDetails = _client.SuccessfulBuildsByBuildConfigName(buildConfigName);

            Assert.That(buildDetails.Any(), "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_failed_build_by_build_configuration_name()
        {
            string buildConfigName = "Local Debug Build";
            var buildDetails = _client.LastFailedBuildByBuildConfigName(buildConfigName);

            Assert.That(buildDetails != null, "No failed builds have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var builds = _client.FailedBuildsByBuildConfigName(buildConfigName);

            Assert.That(builds.Any(), "No failed builds have been found");
        }

        [Test]
        public void it_returns_last_error_build_by_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var buildDetails = _client.LastErrorBuildByBuildConfigName(buildConfigName);

            Assert.That(buildDetails != null, "No errored builds have been found");
        }

        [Test]
        public void it_returns_all_error_builds_by_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var builds = _client.ErrorBuildsByBuildConfigName(buildConfigName);

            Assert.That(builds.Any(), "No errored builds have been found");
        }

        [Test]
        public void it_returns_the_last_build_status_by_build_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var build = _client.LastBuildByBuildConfigName(buildConfigName);

            Assert.That(build != null, "No builds for this build config have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_name()
        {
            string buildConfigName = "Local Debug Build";
            var builds = _client.BuildConfigsByBuildConfigName(buildConfigName);

            Assert.That(builds.Any(), "No builds for this build configuration have been found");
        }

        [Test]
        public void it_returns_all_builds_by_username()
        {
            string userName = "admin";
            var builds = _client.BuildsByUserName(userName);

            Assert.That(builds.Any(), "No builds for this user have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_username()
        {
            string userName = "admin";
            var builds = _client.NonSuccessfulBuildsForUser(userName);

            Assert.That(builds.Any(), "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_non_successful_build_count_by_username()
        {
            string userName = "admin";
            int builds = _client.NonSuccessfulBuildsForUser(userName).Count;

            Assert.That(builds > 0, "No non successful builds found for this user");
        }
    }
}
