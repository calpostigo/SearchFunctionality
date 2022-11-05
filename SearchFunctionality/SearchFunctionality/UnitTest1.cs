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
        public void return_budapest_when_search_equals_to_bu() {

            var charactersToSearch = "Bu";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().Equal(new[] {"Budapest"});
        }

        [Test]
        public void return_Valencia_and_Vancouver_when_search_equals_to_Va() {

            var charactersToSearch = "Va";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().Equal(new[] {"Valencia", "Vancouver"});
        }
    }

    public abstract class Cities {
        private string[] cities = new string[] {
            "Paris","Budapest","Skopje",
            "Rotterdam","Valencia","Vancouver",
            "Amsterdam","Vienna","Sydney",
            "New York City","London","Bangkok"
            ,"Hong Kong","Dubai","Rome","Istanbul"
        };
        public static string[] SearchCities(string search) {
            string[] filteredCities = new string[] { };
            if (search.Length < 2) return filteredCities;
            return new[] { "Budapest" };
        }
    }
}