﻿using ElasticSearchLite.NetCore;
using ElasticSearchLite.Tests.Pocos;
using FluentAssertions;
using System;

namespace ElasticSearchLite.Tests.Integration
{
    public class AbstractIntegrationScenario
    {
        protected static string IndexName { get; } = "exampleindex";
        protected static string TypeName { get; } = "example";
        protected ElasticLiteClient Client { get; } = new ElasticLiteClient("http://localhost:9200/");

        protected Poco poco = new Poco
        {
            Index = IndexName,
            Type = TypeName,
            TestInteger = 12345,
            TestText = "ABCDEFG",
            TestBool = true,
            TestDateTime = new DateTime(2017, 9, 10),
            TestDouble = 1.337,
            TestStringArray = new[] { "A", "B", "C", "D" }
        };

        protected void TestExceptions(Type exception, Action action, string becauseMessage)
        {
            try
            {
                // Act
                action();
            }
            catch (Exception ex)
            {
                // Assert
                ex.GetType().ShouldBeEquivalentTo(exception, becauseMessage);
            }
        }
    }
}
