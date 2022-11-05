using NUnit.Framework;
using System.Net.WebSockets;
using FluentAssertions;

namespace SearchFunctionality {
    public class SearchFuntionalityShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_string_empty_when_search_fewer_than_two_characters() {

            var result = Cities.SearchCities(string.Empty);

            result.Should().BeNullOrEmpty();
        }
    }

    public abstract class Cities {
        public static string[] SearchCities(string search) {
            throw new System.NotImplementedException();
        }
    }
}