using NUnit.Framework;
using FluentAssertions;

namespace SearchFunctionality {
    public class SearchFuntionalityShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_empty_array_when_search_fewer_than_two_characters() {

            var result = Cities.SearchCities(string.Empty);

            result.Should().BeNullOrEmpty();
        }

        [TestCase("V")]
        [TestCase("P")]
        public void return_empty_array_when_search_equals_to_one_character(string characters) {

            var collection = Cities.SearchCities(characters);

            collection.Should().BeNullOrEmpty();
        }

        [Test]
        public void return_cities_array_when_search_equals_to_two_characters() {

            var charactersToSearch = "Va";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().BeNullOrEmpty();
        }
    }

    public abstract class Cities {
        public static string[] SearchCities(string search) {
            string[] filteredCities = new string[] { };
            return filteredCities;
        }
    }
}